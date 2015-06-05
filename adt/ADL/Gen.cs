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
            genProgram(ctx, program);
            return ctx.output.ToString();
        }

        class GenContext
        {
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

            ctx.Appendfnl("public abstract class {0}_MatcherExtensions", nodeVariantsDecl.id);
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            getMatcher(ctx, nodeVariantsDecl, false);
            getMatcher(ctx, nodeVariantsDecl, true);
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
            ctx.NewLine();
        }

        private static void getMatcher(GenContext ctx, NodeVariantsDecl nodeVariantsDecl, bool isFn)
        {
            var args = nodeVariantsDecl.variants
                .Select(x =>
                        string.Format(
                        "{0} {1}_fn",
                        isFn ? string.Format("Func<{0}, T>", x.id) : string.Format("Action<{0}>", x.id),
                        x.id
                    )
                ).ToList();
            args.Add(string.Format("{0} _null_case_fn = null", isFn ? "Func<T>" : "Action"));
            ctx.Appendfnl(
                "public static {0} Match{1}(this {2} __this, {3})",
                isFn ? "T" : "void",
                isFn ? "<T>" : "",
                nodeVariantsDecl.id,
                string.Join(", ", args)
            );
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            for (int i = 0; i < nodeVariantsDecl.attributes.Count; ++i)
            {
                var attr = nodeVariantsDecl.attributes[i];
                ctx.Appendfnl("{0}if (__this is {1})", i == 0 ? "" : "else ", attr.id);
                ctx.Appendfnl("{{");
                ctx.IncreaseIndent();
                ctx.Appendfnl("{0}{1}_fn(__this);", isFn ? "return " : "", attr.id);
                ctx.DecreaseIndent();
                ctx.Appendfnl("}}");
            }
            ctx.Appendfnl("else if (__this == null && _null_case_fn != null)");
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            ctx.Appendfnl("{0}_null_case_fn(__this);", isFn ? "return " : "");
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
            ctx.Appendfnl("else");
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            ctx.Appendfnl("throw new Exception(\"Failed match on {0}\");", nodeVariantsDecl.id);
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
        }

        private static void genVariantNode(GenContext ctx, NodeVariantsDecl nodeVariantsDecl, NodeVariantDecl variant)
        {
            ctx.Appendfnl("public class {0} : {1}", variant.id, nodeVariantsDecl.id);
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            foreach (var field in variant.fields)
            {
                var type = field.type;
                if (field.many)
                {
                    type = "List<" + type + ">";
                }
                var name = field.id ?? (field.many ? field.type : field.type);
                ctx.Appendfnl("public {0} {1} {{ get; set; }}", type, name);
            }
            foreach (var attr in variant.attributes)
            {
                ctx.Appendfnl("public {0} {1} {{ get; set; }}", attr.type, attr.id);
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
                var type = field.type;
                if (field.many)
                {
                    type = "List<" + type + ">";
                }
                var name = field.id ?? (field.many ? field.type : field.type);
                ctx.Appendfnl("public {0} {1} {{ get; set; }}", type, name);
            }
            foreach (var attr in nodeConcreteDecl.attributes)
            {
                ctx.Appendfnl("public {0} {1} {{ get; set; }}", attr.type, attr.id);
            }
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
            ctx.NewLine();
        }
    }
}
