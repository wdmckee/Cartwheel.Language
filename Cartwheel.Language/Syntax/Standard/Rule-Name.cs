using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{

    /*
    rule-name:
	valid-letter-sequence optional?

    */
    public class Rule_Name : Standard
    {

        public Valid_Letter_Sequence valid_letter_sequence;
        public Optional opt_optional;
        public Char_Litteral char_litteral;

        public Rule_Name(Valid_Letter_Sequence _valid_letter_sequence, Optional _opt_optional)
        {
            valid_letter_sequence = _valid_letter_sequence;
            opt_optional = _opt_optional;

            Add(valid_letter_sequence);
            Add(opt_optional);

            UpdateProperties("rule-name");

        }

        public Rule_Name(Char_Litteral _char_litteral)
        {
            char_litteral = _char_litteral;

            Add(char_litteral);
   
            UpdateProperties("rule-name");

        }
    }
}
