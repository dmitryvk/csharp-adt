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
            foreach (var node in program.nodes)
            {
                genNode(ctx, node);
            }
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
            ctx.Appendfnl("public abstract class {0}", nodeVariantsDecl.id);
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
            ctx.Appendfnl("public class {0} : {1}", variant.id, ToNs(ctx, nodeVariantsDecl.id));
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            foreach (var field in variant.fields)
            {
                var type = FieldToCsharpType(ctx, field);
                var name = field.id ?? (field.many ? field.type : field.type);
                ctx.Appendfnl("public {0} {1} {{ get; set; }}", type, name);
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
                        ctx.Appendfnl("this.{0} = new {1}()", field.id, FieldToCsharpType(ctx, field));
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
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
            ctx.NewLine();
        }

        private static void genConcreteNode(GenContext ctx, NodeConcreteDecl nodeConcreteDecl)
        {
            ctx.Appendfnl("public class {0}", nodeConcreteDecl.id);
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            foreach (var field in nodeConcreteDecl.fields)
            {
                var type = FieldToCsharpType(ctx, field);
                var name = field.id ?? (field.many ? field.type : field.type);
                ctx.Appendfnl("public {0} {1} {{ get; set; }}", type, name);
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
                        ctx.Appendfnl("this.{0} = new {1}()", field.id, FieldToCsharpType(ctx, field));
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
    }
}
