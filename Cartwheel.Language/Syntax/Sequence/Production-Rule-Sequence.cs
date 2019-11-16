using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    /*
    production-rule-sequence:
	    production-rule-sequence whitespace-sequence? production-rule 
	    | production-rule ;

    */
    public class Production_Rule_Sequence : Sequence
    {

        public Production_Rule production_rule { get; set; }
        public Whitespace_Sequence opt_whitespace_sequence_1 { get; set; }
        public Production_Rule_Sequence self_production_rule_sequence { get; set; }               


        public Production_Rule_Sequence(Whitespace_Sequence _opt_whitespace_sequence_1, Production_Rule _production_rule, Production_Rule_Sequence _self_production_rule_sequence = null)
        {
            // set values
            opt_whitespace_sequence_1 = _opt_whitespace_sequence_1;
            production_rule = _production_rule;            
            self_production_rule_sequence = _self_production_rule_sequence;

            // add to dictionary
            Add(opt_whitespace_sequence_1);
            Add(production_rule);            
            Add(self_production_rule_sequence);

            // set properties
            UpdateProperties("Production-Rule-Sequence", RecursiveProperty.Right);

        }

        public Production_Rule_Sequence(Production_Rule _production_rule, Production_Rule_Sequence _self_production_rule_sequence = null)
        {
            // set values
            production_rule = _production_rule;

            // add to dictionary
            Add(production_rule);
            Add(self_production_rule_sequence);

            // set properties
            UpdateProperties("Production-Rule-Sequence", RecursiveProperty.Right);

        }

    }
}
