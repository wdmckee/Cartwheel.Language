using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Valid_Letter_Sequence : Sequence
    {


        /*
       valid-letter-sequence:
	    valid-letter-sequence? letter dash letter  
	    | valid-letter-sequence? letter  
	    | valid-letter-sequence dash letter ;

        */


        public Letter letter_1 { get; set; }
        public Dash dash { get; set; }
        public Letter letter_2 { get; set; }
        public Valid_Letter_Sequence self_valid_letter_sequence { get; set; }               


        public Valid_Letter_Sequence(Letter _letter_1, Dash _dash, Letter _letter_2, Valid_Letter_Sequence _self_valid_letter_sequence = null)
        {
            // set values
            letter_1 = _letter_1;
            dash = _dash;
            letter_2 = _letter_2;
            self_valid_letter_sequence = _self_valid_letter_sequence;

            // add to dictionary
            Add(letter_1);
            Add(dash);
            Add(letter_2);
            Add(self_valid_letter_sequence);

            // set properties
            UpdateProperties("Valid-Letter-Sequence", RecursiveProperty.Right);

        }

        public Valid_Letter_Sequence(Letter _letter_1, Valid_Letter_Sequence _self_valid_letter_sequence = null)
        {
            // set values
            letter_1 = _letter_1;
            self_valid_letter_sequence = _self_valid_letter_sequence;

            // add to dictionary
            Add(letter_1);
            Add(self_valid_letter_sequence);

            // set properties
            UpdateProperties("Valid-Letter-Sequence", RecursiveProperty.Right);
        }

        public Valid_Letter_Sequence(Letter _letter_1, Dash _dash, Valid_Letter_Sequence _self_valid_letter_sequence = null)
        {
            // set values
            letter_1 = _letter_1;
            dash = _dash;
            self_valid_letter_sequence = _self_valid_letter_sequence;

            // add to dictionary 
            Add(self_valid_letter_sequence);
            Add(dash);
            Add(letter_1);


            // set properties
            UpdateProperties("Valid-Letter-Sequence", RecursiveProperty.Right);

        }


    }
}
