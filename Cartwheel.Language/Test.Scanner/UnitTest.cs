using Cartwheel.Language;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Scanner_Scan_Success()
        {
            TestSuccess(expression: "rule", AllowedChars: new char[] { 'r','u','l','e'});
            TestSuccess(expression: "full-bnf", AllowedChars: new char[] { '\\', ':', '-', '"', '?', '|', ';', '\'', ' ' , '\r' , '\n', '\t' , 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z','0','1','2','3','4','5','6','7','8','9' });
        }

        [TestMethod]
        public void Scanner_Scan_Failure()
        {
            TestFailure(expression: "rule-name+", AllowedChars: new char[] { 'r', 'u', 'l', 'e' });
        }




        #region Scaffolding


        internal void TestSuccess(string expression, char[] AllowedChars)
        {
            var testResult = Eval(expression, AllowedChars);
            var result = Helper_ConvertListToString(testResult.Tokens);
            Assert.AreEqual(expression, result);
        }

        internal void TestFailure(string expression, char[] AllowedChars)
        {
            var testResult = Eval(expression, AllowedChars);
            Assert.AreEqual(true, testResult.ScanError.HasScanError);
        }






        public ScanResult Eval(string expr, char[] AllowedChars)
        {
            Scanner scanner = new Scanner();
            var result = scanner.Scan(expr, AllowedChars);
            return result;
        }

        internal string Helper_ConvertListToString(IList<Token> _inputlist)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Token token in _inputlist)
            {
                sb.Append(token.StringValue);
            }
            return sb.ToString();
        }

        internal IList<Token> Helper_ConvertStringToList(string _inputexpr)
        {
            IList<Token> _result = new List<Token>();

            int index = 0;
            foreach (char c in _inputexpr)
            {
                var _token = new Token(c, index++);
                _result.Add(_token);
            }
            return _result;
        }

        #endregion



    }
}
