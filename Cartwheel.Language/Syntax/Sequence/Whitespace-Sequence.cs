using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{

    /*
    whitespace-sequence:
	    whitespace-sequence? whitespace ;
    */

    public class Whitespace_Sequence : Sequence
    {
                 


        public Whitespace whitespace_1 { get; set; }
        public Whitespace_Sequence self_whitespace_sequence { get; set; }               


        public Whitespace_Sequence(Whitespace _whitespace_1, Whitespace_Sequence _self_whitespace_sequence = null)
        {
            // set values
            whitespace_1 = _whitespace_1;
            self_whitespace_sequence = _self_whitespace_sequence;

            // add to dictionary
            Add(whitespace_1);
            Add(self_whitespace_sequence);

            // set properties
            UpdateProperties("Whitespace-Sequence", RecursiveProperty.Right);

        }

       

    }
}
