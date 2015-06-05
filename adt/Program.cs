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
            var lexer = new ADLLexer(new ANTLRStringStream(@"
@namespace Foo.Bar.Baz;

foo = bar(foo x) @attributes string y | quux() @common_attributes ""List<int>"" nums;

baz = str, id e1 @attributes double w;

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
