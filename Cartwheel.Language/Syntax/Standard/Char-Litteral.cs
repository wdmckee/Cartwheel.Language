using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{

    /*
    char-litteral:
	    whitespace-sequence? single-quote atomic-symbol single-quote whitespace-sequence? ;
    */

    public class Char_Litteral : Standard
    {


        public Whitespace_Sequence opt_whitespace_sequence_1;
        public Single_Quote single_quote_1;
        public Atomic_Symbol atomic_symbol;
        public Single_Quote single_quote_2;
        public Whitespace_Sequence opt_whitespace_sequence_2;


        public Char_Litteral(Whitespace_Sequence _opt_whitespace_sequence_1, Single_Quote _single_quote_1, Atomic_Symbol _atomic_symbol, Single_Quote _single_quote_2, Whitespace_Sequence _opt_whitespace_sequence_2)
        {
            opt_whitespace_sequence_1 = _opt_whitespace_sequence_1;
            single_quote_1 = _single_quote_1;
            atomic_symbol = _atomic_symbol;
            single_quote_2 = _single_quote_2;
            opt_whitespace_sequence_2 = _opt_whitespace_sequence_2;

            Add(opt_whitespace_sequence_1);
            Add(single_quote_1);
            Add(atomic_symbol);
            Add(single_quote_2);
            Add(opt_whitespace_sequence_2);



            UpdateProperties("char-litteral");

        }





    }
}
