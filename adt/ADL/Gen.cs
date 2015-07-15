using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adt.ADL
{
    public class Gen
    {
        public static string genProgram(ProgramDecl program)
        {
            var ctx = new GenContext();
            ctx.prg = program;
            genProgram(ctx, program);
            return ctx.output.ToString();
        }

        class GenContext
        {
            public ProgramDecl prg;
            public StringBuilder output = new StringBuilder();
            public int indentLevel = 0;
            public bool atNewLine = true;
            public void IncreaseIndent()
            {
                ++indentLevel;
            }
            public void DecreaseIndent()
            {
                --indentLevel;
            }
            public void PrintIndent()
            {
                for (int i = 0; i < indentLevel; ++i)
                {
                    output.Append("  ");
                }
            }
            public void NewLine()
            {
                output.Append("\n");
                atNewLine = true;
            }
            public void Appendf(string format, params object[] args)
            {
                if (atNewLine)
                {
                    PrintIndent();
                    atNewLine = false;
                }
                output.AppendFormat(format, args);
            }
            public void Appendfnl(string format, params object[] args)
            {
                if (atNewLine)
                {
                    PrintIndent();
                    atNewLine = false;
                }
                output.AppendFormat(format, args);
                NewLine();
            }
        }

        private static void genProgram(GenContext ctx, ProgramDecl program)
        {
            ctx.Appendfnl("namespace {0}", string.Join(".", program.ns.ids));
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            if (program.baseClass != null)
            {
                genBaseClass(ctx, program);
            }
            foreach (var node in program.nodes)
            {
                genNode(ctx, node);
            }
            if (program.walker != null)
            {
                genWalker(ctx, program);
            }
            if (program.printer != null)
            {
                genPrinter(ctx, program);
            }
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
        }

        private static void genBaseClass(GenContext ctx, ProgramDecl program)
        {
            ctx.Appendfnl("public abstract partial class {0}", program.baseClass.name);
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            ctx.Appendfnl("public {0} Parent {{ get; set; }}", program.baseClass.name);
            ctx.Appendfnl("public abstract void ReplaceChildNode({0} childNode, {0} newNode);", program.baseClass.name, program.baseClass.name);
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
        }

        private static void genNode(GenContext ctx, NodeDecl node)
        {
            if (node is NodeVariantsDecl)
            {
                genVariantsNode(ctx, (NodeVariantsDecl)node);
            }
            else if (node is NodeConcreteDecl)
            {
                genConcreteNode(ctx, (NodeConcreteDecl)node);
            }
        }

        private static void genVariantsNode(GenContext ctx, NodeVariantsDecl nodeVariantsDecl)
        {
            ctx.Appendfnl("public abstract partial class {0} : {1}", nodeVariantsDecl.id, ctx.prg.baseClass.name);
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            foreach (var attr in nodeVariantsDecl.attributes)
            {
                ctx.Appendfnl("public {0} {1} {{ get; set; }}", attr.type, attr.id);
            }
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");

            foreach (var variant in nodeVariantsDecl.variants)
            {
                genVariantNode(ctx, nodeVariantsDecl, variant);
            }

            ctx.Appendfnl("public static class {0}_MatcherExtensions", nodeVariantsDecl.id);
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            getMatcher(ctx, nodeVariantsDecl, false);
            getMatcher(ctx, nodeVariantsDecl, true);
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
            ctx.NewLine();
        }

        private static string ToNs(GenContext ctx, string type)
        {
            return string.Format("global::{0}.{1}", string.Join(".", ctx.prg.ns.ids), type);
        }

        private static void getMatcher(GenContext ctx, NodeVariantsDecl nodeVariantsDecl, bool isFn)
        {
            var args = nodeVariantsDecl.variants
                .Select(x =>
                        string.Format(
                        "{0} {1}_fn",
                        isFn ? string.Format("global::System.Func<{0}, T>", ToNs(ctx, x.id)) : string.Format("global::System.Action<{0}>", ToNs(ctx, x.id)),
                        x.id
                    )
                ).ToList();
            args.Add(string.Format("{0} _null_case_fn = null", isFn ? "global::System.Func<T>" : "global::System.Action"));
            ctx.Appendfnl(
                "public static {0} Match{1}(this {2} __this, {3})",
                isFn ? "T" : "void",
                isFn ? "<T>" : "",
                ToNs(ctx, nodeVariantsDecl.id),
                string.Join(", ", args)
            );
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            for (int i = 0; i < nodeVariantsDecl.variants.Count; ++i)
            {
                var attr = nodeVariantsDecl.variants[i];
                ctx.Appendfnl("{0}if (__this is {1})", i == 0 ? "" : "else ", ToNs(ctx, attr.id));
                ctx.Appendfnl("{{");
                ctx.IncreaseIndent();
                ctx.Appendfnl("{0}{1}_fn(({2})__this);", isFn ? "return " : "", attr.id, ToNs(ctx, attr.id));
                ctx.DecreaseIndent();
                ctx.Appendfnl("}}");
            }
            ctx.Appendfnl("else if (__this == null && _null_case_fn != null)");
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            ctx.Appendfnl("{0}_null_case_fn();", isFn ? "return " : "");
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
            ctx.Appendfnl("else");
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            ctx.Appendfnl("throw new global::System.Exception(\"Failed match on {0}\");", nodeVariantsDecl.id);
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
        }

        private static void genVariantNode(GenContext ctx, NodeVariantsDecl nodeVariantsDecl, NodeVariantDecl variant)
        {
            ctx.Appendfnl("public partial class {0} : {1}", variant.id, ToNs(ctx, nodeVariantsDecl.id));
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            foreach (var field in variant.fields)
            {
                GenerateField(ctx, field);
            }
            foreach (var attr in variant.attributes)
            {
                ctx.Appendfnl("public {0} {1} {{ get; set; }}", attr.type, attr.id);
            }
            {
                // default constructor
                ctx.Appendfnl("public {0}()", variant.id);
                ctx.Appendfnl("{{");
                foreach (var field in variant.fields)
                {
                    ctx.IncreaseIndent();
                    if (field.many)
                    {
                        ctx.Appendfnl("this.{0} = new {1}();", field.id, FieldToCsharpType(ctx, field));
                    }
                    ctx.DecreaseIndent();
                }
                ctx.Appendfnl("}}");
            }
            if (variant.fields.Count > 0)
            {
                // constructor with parameters
                var fieldsArgs = variant.fields.Select(x => string.Format("{0} {1}_p", FieldToCsharpType(ctx, x), x.id));
                ctx.Appendfnl("public {0}({1})", variant.id, string.Join(", ", fieldsArgs));
                ctx.Appendfnl("{{");
                ctx.IncreaseIndent();

                foreach (var field in variant.fields)
                {
                    var expr = field.id + "_p";
                    if (field.many)
                    {
                        expr = expr + " ?? new " + FieldToCsharpType(ctx, field) + "()";
                    }
                    ctx.Appendfnl("this.{0} = {1};", field.id, expr);
                }

                ctx.DecreaseIndent();
                ctx.Appendfnl("}}");
            }
            genReplaceChildNode(ctx, variant.fields);
            genToString(ctx, variant.id, variant.fields, nodeVariantsDecl.attributes.Concat(variant.attributes).ToList());
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
            ctx.NewLine();
        }

        private static void genReplaceChildNode(GenContext ctx, List<FieldDecl> fields)
        {
            ctx.Appendfnl("public override void ReplaceChildNode({0} oldNode, {0} newNode)", ctx.prg.baseClass.name);
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();

            if (fields.Any(x => x.many))
            {
                ctx.Appendfnl("int __idx = 0;");
            }

            var isFirst = true;
            foreach (var field in fields)
            {
                var name = field.id ?? (field.many ? field.type : field.type);
                if (field.many)
                {
                    ctx.Appendfnl("{0}if ((__idx = this.{1}.IndexOf(({2})oldNode)) != -1)", isFirst ? "" : "else ", name, field.type);
                }
                else
                {
                    ctx.Appendfnl("{0}if (this.{1} == oldNode)", isFirst ? "" : "else ", name);
                }
                isFirst = false;
                ctx.Appendfnl("{{");
                ctx.IncreaseIndent();
                if (field.many)
                {
                    ctx.Appendfnl("if (oldNode.Parent == this)");
                    ctx.Appendfnl("{{");
                    ctx.IncreaseIndent();
                    ctx.Appendfnl("oldNode.Parent = null;");
                    ctx.DecreaseIndent();
                    ctx.Appendfnl("}}");
                    ctx.Appendfnl("this.{0}[__idx] = ({1})newNode;", name, field.type);
                    ctx.Appendfnl("newNode.Parent = this;");
                }
                else
                {
                    ctx.Appendfnl("this.{0} = ({1})newNode;", name, FieldToCsharpType(ctx, field));
                }
                ctx.DecreaseIndent();
                ctx.Appendfnl("}}");
            }
            {
                if (!isFirst)
                {
                    ctx.Appendfnl("else");
                }
                ctx.Appendfnl("{{");
                ctx.IncreaseIndent();
                ctx.Appendfnl("throw new global::System.ArgumentException(\"The node to be replaced is not found in parent node\");");
                ctx.DecreaseIndent();
                ctx.Appendfnl("}}");
            }

            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
        }

        private static void GenerateField(GenContext ctx, FieldDecl field)
        {
            var type = FieldToCsharpType(ctx, field);
            var name = field.id ?? (field.many ? field.type : field.type);
            ctx.Appendfnl("[global::System.CLSCompliant(false)]");
            ctx.Appendfnl("protected {0} __{1};", type, name);
            ctx.Appendfnl("public {0} {1}", type, name);
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            {
                ctx.Appendfnl("get {{ return __{0}; }}", name);
                ctx.Appendfnl("set");
                ctx.Appendfnl("{{");
                ctx.IncreaseIndent();
                {
                    if (!field.optional)
                    {
                        ctx.Appendfnl("if (value == null)", name);
                        ctx.Appendfnl("{{");
                        ctx.IncreaseIndent();
                        {
                            ctx.Appendfnl("throw new global::System.Exception(\"Invalid AST Node assignment: {0} can not be null\");", name);
                        }
                        ctx.DecreaseIndent();
                        ctx.Appendfnl("}}");
                    }
                    ctx.Appendfnl("if (__{0} != null)", name);
                    ctx.Appendfnl("{{");
                    ctx.IncreaseIndent();
                    {
                        if (field.many)
                        {
                            ctx.Appendfnl("foreach (var __item in __{0})", name);
                            ctx.Appendfnl("{{");
                            ctx.IncreaseIndent();
                            {
                                ctx.Appendfnl("if (__item.Parent == this)");
                                ctx.Appendfnl("{{");
                                ctx.IncreaseIndent();
                                {
                                    ctx.Appendfnl("__item.Parent = null;");
                                }
                                ctx.DecreaseIndent();
                                ctx.Appendfnl("}}");
                            }
                            ctx.DecreaseIndent();
                            ctx.Appendfnl("}}");
                        }
                        else
                        {
                            ctx.Appendfnl("if ( __{0}.Parent == this)", name);
                            ctx.Appendfnl("{{");
                            ctx.IncreaseIndent();
                            {
                                ctx.Appendfnl(" __{0}.Parent = null;", name);
                            }
                            ctx.DecreaseIndent();
                            ctx.Appendfnl("}}");
                        }
                    }
                    ctx.DecreaseIndent();
                    ctx.Appendfnl("}}");

                    ctx.Appendfnl("__{0} = value;", name);

                    ctx.Appendfnl("if (__{0} != null)", name);
                    ctx.Appendfnl("{{");
                    ctx.IncreaseIndent();
                    {
                        if (field.many)
                        {
                            ctx.Appendfnl("foreach (var __item in __{0})", name);
                            ctx.Appendfnl("{{");
                            ctx.IncreaseIndent();
                            {
                                ctx.Appendfnl("__item.Parent = this;");
                            }
                            ctx.DecreaseIndent();
                            ctx.Appendfnl("}}");
                        }
                        else
                        {
                            ctx.Appendfnl(" __{0}.Parent = this;", name);
                        }
                    }
                    ctx.DecreaseIndent();
                    ctx.Appendfnl("}}");
                }
                ctx.DecreaseIndent();
                ctx.Appendfnl("}}");
            }
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
        }

        private static void genConcreteNode(GenContext ctx, NodeConcreteDecl nodeConcreteDecl)
        {
            ctx.Appendfnl("public partial class {0} : {1}", nodeConcreteDecl.id, ctx.prg.baseClass.name);
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            foreach (var field in nodeConcreteDecl.fields)
            {
                GenerateField(ctx, field);
            }
            foreach (var attr in nodeConcreteDecl.attributes)
            {
                ctx.Appendfnl("public {0} {1} {{ get; set; }}", attr.type, attr.id);
            }
            {
                // default constructor
                ctx.Appendfnl("public {0}()", nodeConcreteDecl.id);
                ctx.Appendfnl("{{");
                foreach (var field in nodeConcreteDecl.fields)
                {
                    ctx.IncreaseIndent();
                    if (field.many)
                    {
                        ctx.Appendfnl("this.{0} = new {1}();", field.id, FieldToCsharpType(ctx, field));
                    }
                    ctx.DecreaseIndent();
                }
                ctx.Appendfnl("}}");
            }
            if (nodeConcreteDecl.fields.Count > 0)
            {
                // constructor with parameters
                var fieldsArgs = nodeConcreteDecl.fields.Select(x => string.Format("{0} {1}_p", FieldToCsharpType(ctx, x), x.id));
                ctx.Appendfnl("public {0}({1})", nodeConcreteDecl.id, string.Join(", ", fieldsArgs));
                ctx.Appendfnl("{{");
                ctx.IncreaseIndent();

                foreach (var field in nodeConcreteDecl.fields)
                {
                    var expr = field.id + "_p";
                    if (field.many)
                    {
                        expr = expr + " ?? new " + FieldToCsharpType(ctx, field) + "()";
                    }
                    ctx.Appendfnl("this.{0} = {1};", field.id, expr);
                }

                ctx.DecreaseIndent();
                ctx.Appendfnl("}}");
            }
            genReplaceChildNode(ctx, nodeConcreteDecl.fields);
            genToString(ctx, nodeConcreteDecl.id, nodeConcreteDecl.fields, nodeConcreteDecl.attributes);
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
            ctx.NewLine();
        }

        private static void genToString(GenContext ctx, string id, List<FieldDecl> fields, List<AttributeDecl> attributes)
        {
            ctx.Appendfnl("public override string ToString()");
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            {
                var printedAttributes = attributes.Where(x => x.printed).ToList();
                var count = fields.Count + printedAttributes.Count;
                ctx.Appendfnl("var result = new global::System.Text.StringBuilder();");
                ctx.Appendfnl("var __first = false;");
                //StringBuilder sb;
                //sb.Append(
                ctx.Appendfnl("result.Append(\"{0}(\");", id);
                var first = true;
                foreach (var field in fields)
                {
                    if (first)
                    {
                        ctx.Appendfnl("result.Append(\"\\n  \");");
                    }
                    else
                    {
                        ctx.Appendfnl("result.Append(\",\\n  \");");
                    }
                    first = false;
                    if (field.many)
                    {
                        ctx.Appendfnl("result.Append(\"[\");");
                        ctx.Appendfnl("__first = true;");
                        ctx.Appendfnl("foreach (var __item in this.{0})", field.id);
                        ctx.Appendfnl("{{");
                        ctx.IncreaseIndent();
                        {
                            ctx.Appendfnl("if (!__first) result.Append(\",\");");
                            ctx.Appendfnl("result.Append(\"\\n    \");");
                            ctx.Appendfnl("__first = false;");
                            ctx.Appendfnl("result.Append(__item.ToString().Replace(\"\\n\", \"\\n    \"));");
                        }
                        ctx.DecreaseIndent();
                        ctx.Appendfnl("}}");
                        ctx.Appendfnl("if (!__first) result.Append(\"\\n  \");");
                        ctx.Appendfnl("result.Append(\"]\");");
                    }
                    else
                    {
                        ctx.Appendfnl("if (this.{0} == null)", field.id);
                        ctx.Appendfnl("{{");
                        ctx.IncreaseIndent();
                        {
                            ctx.Appendfnl("result.Append(\"null\");");
                        }
                        ctx.DecreaseIndent();
                        ctx.Appendfnl("}}");
                        ctx.Appendfnl("else");
                        ctx.Appendfnl("{{");
                        ctx.IncreaseIndent();
                        {
                            ctx.Appendfnl("result.Append(this.{0}.ToString().Replace(\"\\n\", \"\\n  \"));", field.id);
                        }
                        ctx.DecreaseIndent();
                        ctx.Appendfnl("}}");
                    }
                }
                foreach (var attr in printedAttributes)
                {
                    if (count > 1)
                    {
                        if (first)
                        {
                            ctx.Appendfnl("result.Append(\"\\n  \");");
                        }
                        else
                        {
                            ctx.Appendfnl("result.Append(\",\\n  \");");
                        }
                    }
                    first = false;
                    ctx.Appendfnl("if ((object)this.{0} == null)", attr.id);
                    ctx.Appendfnl("{{");
                    ctx.IncreaseIndent();
                    {
                        ctx.Appendfnl("result.Append(\"null\");");
                    }
                    ctx.DecreaseIndent();
                    ctx.Appendfnl("}}");
                    ctx.Appendfnl("else");
                    ctx.Appendfnl("{{");
                    ctx.IncreaseIndent();
                    {
                        ctx.Appendfnl("result.Append(this.{0}.ToString().Replace(\"\\n\", \"\\n  \"));", attr.id);
                    }
                    ctx.DecreaseIndent();
                    ctx.Appendfnl("}}");
                }
                ctx.Appendfnl("result.Append(\")\");");
                ctx.Appendfnl("return result.ToString();");
            }
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
            ctx.NewLine();
        }

        private static string FieldToCsharpType(GenContext ctx, FieldDecl field)
        {
            var type = ToNs(ctx, field.type);
            if (field.many)
            {
                type = "global::System.Collections.Generic.List<" + type + ">";
            }
            return type;
        }

        private static void genWalker(GenContext ctx, ProgramDecl program)
        {
            ctx.Appendfnl("public class {0}", program.walker.name);
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            foreach (var node in program.nodes)
            {
                if (node is NodeVariantsDecl)
                {
                    genWalkerVariants(ctx, (NodeVariantsDecl)node);
                }
                else
                {
                    genWalkerConcrete(ctx, (NodeConcreteDecl)node);
                }
            }
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
        }

        private static void genWalkerConcrete(GenContext ctx, NodeConcreteDecl nodeConcreteDecl)
        {
            ctx.Appendfnl("public virtual void walk{0}({1} __node)", nodeConcreteDecl.id, ToNs(ctx, nodeConcreteDecl.id));
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            var nodeName = nodeConcreteDecl.id;
            foreach (var field in nodeConcreteDecl.fields)
            {
                genWalkerField(ctx, nodeName, field);
            }
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
        }

        private static void genWalkerField(GenContext ctx, string nodeName, FieldDecl field)
        {
            if (field.many)
            {
                ctx.Appendfnl("for (var __idx = 0; __idx < __node.{0}.Count; ++__idx)", field.id);
                ctx.Appendfnl("{{");
                ctx.IncreaseIndent();
                ctx.Appendfnl("this.walk{0}(__node.{1}[__idx]);", field.type, field.id);
                ctx.DecreaseIndent();
                ctx.Appendfnl("}}");
            }
            else
            {
                if (!field.optional)
                {
                    ctx.Appendfnl("if (__node.{0} == null)", field.id);
                    ctx.Appendfnl("{{");
                    ctx.IncreaseIndent();
                    ctx.Appendfnl("throw new global::System.InvalidOperationException(\"Required field {0} of node {1} is empty\");", field.id, nodeName);
                    ctx.DecreaseIndent();
                    ctx.Appendfnl("}}");
                }
                ctx.Appendfnl("if (__node.{0} != null)", field.id);
                ctx.Appendfnl("{{");
                ctx.IncreaseIndent();
                ctx.Appendfnl("this.walk{0}(__node.{1});", field.type, field.id);
                ctx.DecreaseIndent();
                ctx.Appendfnl("}}");
            }
        }

        private static void genWalkerVariants(GenContext ctx, NodeVariantsDecl node)
        {
            ctx.Appendfnl("public virtual void walk{0}({1} __node)", node.id, ToNs(ctx, node.id));
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            ctx.Appendfnl("__node.Match");
            ctx.Appendfnl("(");
            ctx.IncreaseIndent();
            for (var i = 0; i < node.variants.Count; ++i)
            {
                var isLast = i == node.variants.Count - 1;
                var variant = node.variants[i];
                ctx.Appendfnl("walk{0}{1}", variant.id, isLast ? "" : ",");
            }
            ctx.DecreaseIndent();
            ctx.Appendfnl(");");
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");

            foreach (var variant in node.variants)
            {
                genWalkerVariants(ctx, variant);
            }
        }

        private static void genWalkerVariants(GenContext ctx, NodeVariantDecl variant)
        {
            ctx.Appendfnl("public virtual void walk{0}({1} __node)", variant.id, ToNs(ctx, variant.id));
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            var nodeName = variant.id;
            foreach (var field in variant.fields)
            {
                genWalkerField(ctx, nodeName, field);
            }
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
        }

        private static void genPrinter(GenContext ctx, ProgramDecl program)
        {
            if (program.walker == null)
            {
                throw new InvalidOperationException("Walker must be specified in order to use printer");
            }
            ctx.Appendfnl("public class {0} : {1}", program.printer.name, program.walker.name);
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            ctx.Appendfnl("global::System.IO.TextWriter writer;");
            ctx.Appendfnl("int indentLevel = 0;");
            ctx.Appendfnl("bool atNewLine = true;");
            ctx.Appendfnl("void IncreaseIndent()");
            ctx.Appendfnl("{{");
            ctx.Appendfnl("    ++indentLevel;");
            ctx.Appendfnl("}}");
            ctx.Appendfnl("void DecreaseIndent()");
            ctx.Appendfnl("{{");
            ctx.Appendfnl("    --indentLevel;");
            ctx.Appendfnl("}}");
            ctx.Appendfnl("void PrintIndent()");
            ctx.Appendfnl("{{");
            ctx.Appendfnl("    for (int i = 0; i < indentLevel; ++i)");
            ctx.Appendfnl("    {{");
            ctx.Appendfnl("        writer.Write(\"  \");");
            ctx.Appendfnl("    }}");
            ctx.Appendfnl("}}");
            ctx.Appendfnl("void NewLine()");
            ctx.Appendfnl("{{");
            ctx.Appendfnl("    writer.Write(\"\\n\");");
            ctx.Appendfnl("    atNewLine = true;");
            ctx.Appendfnl("}}");
            ctx.Appendfnl("public void Appendf(string format, params object[] args)");
            ctx.Appendfnl("{{");
            ctx.Appendfnl("    if (atNewLine)");
            ctx.Appendfnl("    {{");
            ctx.Appendfnl("        PrintIndent();");
            ctx.Appendfnl("        atNewLine = false;");
            ctx.Appendfnl("    }}");
            ctx.Appendfnl("    writer.Write(format, args);");
            ctx.Appendfnl("}}");
            ctx.Appendfnl("public void Appendfnl(string format, params object[] args)");
            ctx.Appendfnl("{{");
            ctx.Appendfnl("    if (atNewLine)");
            ctx.Appendfnl("    {{");
            ctx.Appendfnl("        PrintIndent();");
            ctx.Appendfnl("        atNewLine = false;");
            ctx.Appendfnl("    }}");
            ctx.Appendfnl("    writer.Write(format, args);");
            ctx.Appendfnl("    NewLine();");
            ctx.Appendfnl("}}");
            ctx.Appendfnl("public static string PrintAst(global::{0}.{1} __node)", string.Join(".", program.ns.ids), program.printer.root);
            ctx.Appendfnl("{{");
            ctx.Appendfnl("    var sw = new global::System.IO.StringWriter();");
            ctx.Appendfnl("    var printer = new {0}(sw);", program.printer.name);
            ctx.Appendfnl("    printer.walk{0}(__node);", program.printer.root);
            ctx.Appendfnl("    return sw.ToString();");
            ctx.Appendfnl("}}");
            ctx.Appendfnl("");
            ctx.Appendfnl("public {0}(global::System.IO.TextWriter writer)", program.printer.name);
            ctx.Appendfnl("{{");
            ctx.Appendfnl("    this.writer = writer;");
            ctx.Appendfnl("}}");

            foreach (var type in program.nodes)
            {
                if (type is NodeVariantsDecl)
                {
                    var theType = (NodeVariantsDecl)type;
                    foreach (var variant in theType.variants)
                    {
                        var printedAttributes = type.attributes.Concat(variant.attributes).Where(x => x.printed).ToList();
                        var typeName = variant.id;
                        GenPrinterHeader(ctx, program, printedAttributes, typeName);
                    }
                }
                else if (type is NodeConcreteDecl)
                {
                    var theType = (NodeConcreteDecl)type;
                    var printedAttributes = theType.attributes.Where(x => x.printed).ToList();
                    var typeName = theType.id;
                    GenPrinterHeader(ctx, program, printedAttributes, typeName);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
        }

        private static void GenPrinterHeader(GenContext ctx, ProgramDecl program, List<AttributeDecl> printedAttributes, string typeName)
        {
            var attrFormats = string.Join(", ", printedAttributes.Select((x, i) => x.id + "={" + i + "}"));
            var attrRefs = string.Join(", ", printedAttributes.Select(x => "__node." + x.id));
            if (attrFormats != "")
            {
                attrFormats = " " + attrFormats;
            }
            if (attrRefs != "")
            {
                attrRefs = ", " + attrRefs;
            }
            ctx.Appendfnl("public override void walk{0}(global::{1}.{0} __node)", typeName, string.Join(".", program.ns.ids));
            ctx.Appendfnl("{{");
            ctx.Appendfnl("  if (!atNewLine)");
            ctx.Appendfnl("  {{");
            ctx.Appendfnl("    NewLine();");
            ctx.Appendfnl("  }}");
            ctx.Appendfnl("  Appendf(\"({0}{1}\"{2});", typeName, attrFormats, attrRefs);
            ctx.Appendfnl("  IncreaseIndent();");
            ctx.Appendfnl("  base.walk{0}(__node);", typeName);
            ctx.Appendfnl("  Appendf(\")\");");
            ctx.Appendfnl("  DecreaseIndent();");
            ctx.Appendfnl("}}");
        }
    }
}
