using adt.ADL;
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
            if (args.Length == 0)
            {
                DebugRun();
            }
            else
            {
                var input = File.ReadAllText(args[0]);
                var lexer = new ADLLexer(new ANTLRStringStream(input));
                var tokenStream = new CommonTokenStream(lexer);
                var parser = new ADLParser(tokenStream);
                var program = parser.program();
                var programSrc = Gen.genProgram(program);
                File.WriteAllText(args[1], programSrc);
            }
        }

        private static void DebugRun()
        {
            var lexer = new ADLLexer(new ANTLRStringStream(@"
@namespace Foo.Bar.Baz;
@baseclass BaseNode;
@walker BaseWalker;
@printer AstPrinter Statement;

Statement = Select(SelectStatement) | Update(UpdateStatement) | Delete(DeleteStatement) | Insert(InsertStatement);

SelectStatement = Query;
UpdateStatement = ;
DeleteStatement = ;
InsertStatement = ;

Query = FromClause, SelectClause, WhereClause?;

FromClause = TableRef* Sources;

TableRef = Id Name, Id? Alias;

SelectClause = AliasedExpr* Exprs;

WhereClause = Expr;

AliasedExpr = Expr, Id? Alias;

Expr = IdExpr(Id) | DotExpr(Expr, Id);

Id = @attributes @printed string value, int length;
"));


            var tokenStream = new CommonTokenStream(lexer);
            var parser = new ADLParser(tokenStream);
            var program = parser.program();

            var programSrc = Gen.genProgram(program);

            Console.WriteLine();
        }
    }
}
