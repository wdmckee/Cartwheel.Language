using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class ParseResult
    {


        public Syntax Syntax { get; set; }

        public ParseResult(Syntax data)
        {
            Syntax = data;


            //this.Syntax.Information_RecursiveSyntaxFound();// this should always be checked first
            //this.Syntax.Information_ProductionRuleConsecutiveValues(new List<string> { "rule-name", "Optional", "Pipe" }, "Warning2.1");

            //this.Syntax.Emit_ILCode(new List<string> { "production-name", "rule-name", "Pipe", "Semi-Colon" , "Optional"});
        }

        




        #region OLD CODE
        //public string Expression { get; set; }
        //public dynamic Value { get; set; }
        //public bool IsError { get; set; }
        //public Type Type { get; set; }
        //public bool HasParseError { get; set; }
        ////public bool IsValidated { get; set; }


        //public void SetResult(dynamic data)
        //{
        //    if (data != null)
        //        IsError = false;
        //    else
        //        IsError = true;



        //    Value = data;
        //    Type = Value.GetType();
        //    if (data is string)
        //    { Expression = data; }
        //    else
        //    {
        //        Expression = data?.Properties.Expression;
        //        //Properties.Expression = Expression;
        //    }

        //}
        #endregion





    }
}
