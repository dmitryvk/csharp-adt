using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adt
{
    public class AstTypeGen
    {
        public static string GenerateAstTypeDefinition(IEnumerable<AstNodeType> ast)
        {
            return string.Join("\n\n", ast.Select(x => GenerateAstTypeDefinition(x)));
        }

        public static string GenerateAstTypeDefinition(AstNodeType ast)
        {
            StringBuilder result = new StringBuilder();

            if (ast is AstNonVariantType)
            {
                WriteNonVariantNodeType((AstNonVariantType)ast, result);
            }
            else
            {
                WriteVariantNodeType((AstVariantType)ast, result);
            }

            return result.ToString();
        }

        private static void WriteNonVariantNodeType(AstNonVariantType ast, StringBuilder result)
        {
            result.AppendFormat(
@"public partial class {0}
{{
",
                ast.Name);
            foreach (var field in ast.Fields)
            {
                WriteField(result, field);
            }
            result.AppendFormat(
@"    public {0}()
    {{",
                ast.Name
);
            foreach (var field in ast.Fields)
            {
                if (field.Initializer != null)
                {
                    result.AppendLine();
                    WriteFieldInitializer(result, field);
                }
            }
            result.AppendLine("    }");
            result.AppendFormat(
@"    public {0}({1})
    {{",
                ast.Name,
                string.Join(", ", ast.Fields.Select(x => string.Format("{0} {1}", x.Type, x.Name)))
);
            foreach (var field in ast.Fields)
            {
                result.AppendLine();
                WriteFieldAssignment(result, field);
            }
            result.AppendLine("    }");
            result.AppendFormat(
@"    public static {0} Create({1})
    {{
        return new {0}({2});
    }}
",
                ast.Name,
                string.Join(", ", ast.Fields.Select(x => string.Format("{0} {1}", x.Type, x.Name))),
                string.Join(", ", ast.Fields.Select(x => x.Name))
);
            result.AppendLine("}");
        }

        private static void WriteVariantNodeType(AstVariantType ast, StringBuilder result)
        {

            result.AppendFormat("public abstract partial class {0}\n", ast.Name);
            result.AppendLine("{");
            foreach (var variant in ast.Variants)
            {
                result.AppendFormat(
    @"    public static {0} Create{0}({1})
    {{
        return new {0}({2});
    }}
",
                    variant.Name,
                    string.Join(", ", variant.Fields.Select(x => string.Format("{0} {1}", x.Type, x.Name))),
                    string.Join(", ", variant.Fields.Select(x => x.Name))
    );
            }
            result.AppendLine("}");
            result.AppendLine();

            foreach (var variant in ast.Variants)
            {
                result.AppendFormat("public partial class {0} : {1}\n", variant.Name, ast.Name);
                result.AppendLine("{");
                foreach (var field in variant.Fields)
                {
                    result.AppendFormat("    public {0} {1} {{ get; set; }}\n", field.Type, field.Name);
                }
                result.AppendFormat("    public {0} ()\n", variant.Name);
                result.AppendLine("    {");
                foreach (var field in variant.Fields)
                {
                    if (field.Initializer != null)
                    {
                        result.AppendFormat("        this.{0} = {1};\n", field.Name, field.Initializer);
                    }
                }
                result.AppendLine("    }");
                result.AppendFormat("    public {0} ({1})\n", variant.Name, string.Join(", ", variant.Fields.Select(x => string.Format("{0} {1}", x.Type, x.Name))));
                result.AppendLine("    {");
                foreach (var field in variant.Fields)
                {
                    result.AppendFormat("        this.{0} = {0};\n", field.Name);
                }
                result.AppendLine("    }");
                result.AppendLine("}");
                result.AppendLine();
            }

            result.AppendFormat("public static class {0}MatchExtensions\n", ast.Name);
            result.AppendLine("{");
            result.AppendFormat("    public static void Match(this {0} __instance, {1})\n",
                ast.Name,
                string.Join(", ", ast.Variants.Select(x => string.Format("Action<{0}> act_{0}", x.Name))));
            result.AppendLine("    {");
            var first = true;
            foreach (var variant in ast.Variants)
            {
                result.Append("        ");
                if (!first)
                {
                    result.Append("else ");
                }

                first = false;

                result.AppendFormat("if (__instance is {0}) {{\n", variant.Name);
                result.AppendFormat("            act_{0}(({0})__instance);\n", variant.Name);
                result.AppendLine("        }");
            }
            result.AppendLine("        else {");
            result.AppendLine("            throw new ArgumentException();");
            result.AppendLine("        }");
            result.AppendLine("    }");

            result.AppendFormat("    public static T Match<T>(this {0} __instance, {1})\n",
                ast.Name,
                string.Join(", ", ast.Variants.Select(x => string.Format("Func<{0}, T> fn_{0}", x.Name))));
            result.AppendLine("    {");
            first = true;
            foreach (var variant in ast.Variants)
            {
                result.Append("        ");
                if (!first)
                {
                    result.Append("else ");
                }

                first = false;

                result.AppendFormat("if (__instance is {0}) {{\n", variant.Name);
                result.AppendFormat("            return fn_{0}(({0})__instance);\n", variant.Name);
                result.AppendLine("        }");
            }
            result.AppendLine("        else {");
            result.AppendLine("            throw new ArgumentException();");
            result.AppendLine("        }");
            result.AppendLine("    }");
            result.AppendLine("}");
        }

        private static void WriteFieldAssignment(StringBuilder result, AstField field)
        {
            result.AppendFormat("        this.{0} = {0};\n", field.Name);
        }

        private static void WriteFieldInitializer(StringBuilder result, AstField field)
        {
            result.AppendFormat("        this.{0} = {1};\n", field.Name, field.Initializer);
        }

        private static void WriteField(StringBuilder result, AstField field)
        {
            result.AppendFormat("    public {0} {1} {{ get; set; }}\n", field.Type, field.Name);
        }
    }
}
