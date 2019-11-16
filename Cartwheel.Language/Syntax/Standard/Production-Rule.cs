using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    /*
    production-rule:
	    production-name whitespace-sequence? rule-name-sequence whitespace-sequence? semi-colon  whitespace-sequence?;
    */

    public class Production_Rule : Standard
    {

        public Production_Name production_name { get; set; }
        public Whitespace_Sequence opt_whitespace_sequence_1 { get; set; }
        public Rule_Name_Sequence rule_name_sequence { get; set; }
        public Whitespace_Sequence opt_whitespace_sequence_2 { get; set; }
        public Semi_Colon semi_colon { get; set; }
        public Whitespace_Sequence opt_whitespace_sequence_3 { get; set; }

        public Production_Rule(Production_Name _production_name, Whitespace_Sequence _opt_whitespace_sequence_1, Rule_Name_Sequence _rule_name_sequence, Whitespace_Sequence _opt_whitespace_sequence_2, Semi_Colon _semi_colon, Whitespace_Sequence _opt_whitespace_sequence_3)
        {
            production_name = _production_name;
            opt_whitespace_sequence_1 = _opt_whitespace_sequence_1;
            rule_name_sequence = _rule_name_sequence;
            opt_whitespace_sequence_2 = _opt_whitespace_sequence_2;
            semi_colon = _semi_colon;
            opt_whitespace_sequence_3 = _opt_whitespace_sequence_3;

            Add(production_name);
            Add(opt_whitespace_sequence_1);
            Add(rule_name_sequence);
            Add(opt_whitespace_sequence_2);            
            Add(semi_colon);
            Add(opt_whitespace_sequence_3);

            UpdateProperties("production-rule");

        }
    }
}
