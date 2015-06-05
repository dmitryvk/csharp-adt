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
            foreach (var variant in nodeVariantsDecl.variants)
            {
                genVariantNode(ctx, variant);
            }
            ctx.DecreaseIndent();
            ctx.Appendfnl("}}");
            ctx.NewLine();
        }

        private static void genVariantNode(GenContext ctx, NodeVariantDecl variant)
        {
            ctx.Appendfnl("public class {0}", variant.id);
            ctx.Appendfnl("{{");
            ctx.IncreaseIndent();
            foreach (var field in variant.fields)
            {
                var type = field.type;
                if (field.many)
                {
                    type = "List<" + type + ">";
                }
                var name = field.id ?? (field.many ? field.type + "s" : field.type);
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
                var name = field.id ?? (field.many ? field.type + "s" : field.type);
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
