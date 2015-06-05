using adt.ADL;
using adt.adt;
using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adt
{
    class Program
    {
        static void Main(string[] args)
        {
            var lexer = new ADLLexer(new ANTLRStringStream(@"
@namespace Foo.Bar.Baz;

foo = bar(foo x) @attributes string y | quux() @common_attributes ""List<int>"" nums;

baz = str, id e1 @attributes double w;

statement = Select(selectStatement) | Update(updateStatement) | Delete(deleteStatement) | Insert(insertStatement);

selectStatement = query @attributes ""List<QS>"" QuerySources;
"));

            
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new ADLParser(tokenStream);
            var program = parser.program();

            var programSrc = Gen.genProgram(program);

            Console.WriteLine();
//            var td1 = new AstNonVariantType
//            {
//                Name = "BinaryOp",
//                Fields =
//                {
//                    new AstField { Name = "OpType", Type = "char", Initializer = "'+'" },
//                    new AstField { Name = "LHS", Type = "Expression" },
//                    new AstField { Name = "RHS", Type = "Expression" },
//                }
//            };

//            var td2 = new AstVariantType
//            {
//                Name = "FromElement",
//                Variants =
//                {
//                    new AstVariant
//                    {
//                        Name = "Range",
//                        Fields =
//                        {
//                            new AstField { Name = "Path", Type = "object" },
//                            new AstField { Name = "Fetch", Type = "bool" },
//                        }
//                    },
//                    new AstVariant
//                    {
//                        Name = "JoinElement",
//                        Fields =
//                        {
//                            new AstField { Name = "JoinType", Type = "int" },
//                            new AstField { Name = "PropertyRef", Type = "string" },
//                        }
//                    },
//                }
//            };

//            var td3 = AstTypesParser.ParseTypes(@"
//node SelectStatement = From:FromElement  Select:Expr;
//
//node_variants Expr =
//    BinaryOp Op:char  LHS: Expr  RHS: Expr
//    | UnaryOp Op:char  Operand: Expr
//    | StringLiteral Value:string
//    | IntegerLiteral Value:int;
//
//node_variants FromElement =
//    Range Path:string  Fetch:bool
//    | FilterEntity Alias:string;
//");

//            var src1 = AstTypeGen.GenerateAstTypeDefinition(td1);
//            var src2 = AstTypeGen.GenerateAstTypeDefinition(td2);
//            var src3 = string.Join("\n\n", td3.Select(x => AstTypeGen.GenerateAstTypeDefinition(x)));

//            var hqlAstDefStream = typeof(Program).Assembly.GetManifestResourceStream(typeof(Program).Namespace + ".HQL.txt");
//            using (var ms = new MemoryStream())
//            {
//                hqlAstDefStream.CopyTo(ms);
//                var str = Encoding.UTF8.GetString(ms.ToArray());
//                var hqlDef = AstTypesParser.ParseTypes(str);
//                var hqlDefCsharp = AstTypeGen.GenerateAstTypeDefinition(hqlDef);
//            }
        }
    }
}
