//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.5.0.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using adt.ADL;


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Misc;
using System;

namespace adt
{
    public partial class ADLParser
    {
        public override void ReportError(RecognitionException e)
        {
            Console.WriteLine("Error {3} at {0}:{1}: {2} near {4}", e.Line, e.CharPositionInLine, e.Message, e.GetType().FullName, e.Token.Text);
            throw e;
        }
    }

} // namespace  adt 
