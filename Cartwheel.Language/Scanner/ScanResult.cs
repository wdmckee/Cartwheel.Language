using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class ScanResult
    {


        public IList<Token> Tokens { get; set; }

        public Error ScanError = new Error();
        public int CurrentReadIndex { get; set; }
        public Token CurrentToken { get { return GetCurrentToken(); } }
        public bool IsEOL { get { return EOL(); } }


        private bool EOL()
        {
            if (CurrentReadIndex >= Tokens.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private Token GetCurrentToken()
        {
            return IsEOL ? Tokens[CurrentReadIndex - 1] : Tokens[CurrentReadIndex];
        }




    }
}
