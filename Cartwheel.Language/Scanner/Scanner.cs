using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cartwheel.Language
{
    public class Scanner
    {


        /// <summary>Scan is a method in the  <see cref="Cartwheel.Language.Scanner"/> class
        /// <para>
        /// Scan is responsible for calling the char by char processing of the input text.
        /// It returns a ScanResult object.
        /// </para>
        /// </summary>
        /// 



        private char[] _allowedCharList;
        private string _inputexpr;
        


        public ScanResult Scan(string InputExpr, char[] AllowedCharList= null)
        {

            

            ScanResult result = new ScanResult();
            IList<Token> _resultList = new List<Token>();
            int _index = 0;
            _inputexpr = InputExpr;
            _allowedCharList = AllowedCharList;




            foreach (char c in _inputexpr)
            {
                
                if ( _allowedCharList == null || _allowedCharList.Contains(c)  )
                {
                    var _token = new Token(c, _index);
                    _resultList.Add(_token);
                    _index++;
                }
                else
                {
                    result.ScanError.HasScanError = true;
                    result.ScanError.ScanErrorLocation = _index;
                    result.ScanError.ScanErrorChar = c;
                    return result;
                }
            }

       




            result.Tokens = _resultList;


            return result;
        }

        
    }
}
