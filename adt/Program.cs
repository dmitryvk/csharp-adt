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
@printer AstPrinter foo;

foo = bar(foo x) @attributes @printed string y | quux() @common_attributes @printed ""List<int>"" nums;

baz = str, id e1 @attributes @printed double w;

statement = Select(selectStatement) | Update(updateStatement) | Delete(deleteStatement) | Insert(insertStatement);

selectStatement = query @attributes ""List<QS>"" QuerySources;

path1 = Foo*;

path2 = StringPath() @attributes string val | IdPath(Id* identifiers);
"));


            var tokenStream = new CommonTokenStream(lexer);
            var parser = new ADLParser(tokenStream);
            var program = parser.program();

            var programSrc = Gen.genProgram(program);

            Console.WriteLine();
        }
    }
}
