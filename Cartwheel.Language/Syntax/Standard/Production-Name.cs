using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{

    /*

    production-name:
	    valid-letter-sequence colon;

    */
    public class Production_Name : Standard
    {

        public Valid_Letter_Sequence valid_letter_sequence;
        public Colon colon;

        public Production_Name(Valid_Letter_Sequence _valid_letter_sequence, Colon _colon)
        {
            valid_letter_sequence = _valid_letter_sequence;
            colon = _colon;

            Add(valid_letter_sequence);
            Add(colon);

            UpdateProperties("production-name");

        }
    }
}
