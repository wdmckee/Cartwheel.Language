using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Rule_Name_Sequence : Sequence
    {


        /*
     rule-name-sequence:
	    rule-name-sequence? rule-name whitespace-sequence? pipe whitespace-sequence? rule-name
	    | rule-name-sequence? whitespace-sequence? rule-name 
	    | rule-name-sequence whitespace-sequence? pipe whitespace-sequence? rule-name ;


        */


        public Rule_Name rule_name_1 { get; set; }
        public Rule_Name rule_name_2 { get; set; }
        public Whitespace_Sequence opt_whitespace_sequence_1 { get; set; }
        public Pipe pipe_1 { get; set; }
        public Whitespace_Sequence opt_whitespace_sequence_2 { get; set; }
        public Rule_Name_Sequence self_rule_name_sequence { get; set; }

        
        public Rule_Name_Sequence( Rule_Name _rule_name_1,  Whitespace_Sequence _opt_whitespace_sequence_1,  Pipe _pipe_1,Whitespace_Sequence _opt_whitespace_sequence_2, Rule_Name _rule_name_2, Rule_Name_Sequence _self_rule_name_sequence = null)
        {
            // set values
            rule_name_1 = _rule_name_1;
            opt_whitespace_sequence_1 = _opt_whitespace_sequence_1;
            pipe_1 = _pipe_1;
            opt_whitespace_sequence_2 = _opt_whitespace_sequence_2;
            rule_name_2 = _rule_name_2;
            self_rule_name_sequence = _self_rule_name_sequence;

            // add to dictionary
            Add(rule_name_1);
            Add(opt_whitespace_sequence_1);
            Add(pipe_1);
            Add(opt_whitespace_sequence_2);
            Add(rule_name_2);
            Add(self_rule_name_sequence);


            // set properties
            UpdateProperties("Rule-Name-Sequence", RecursiveProperty.Right);

        }
        
        public Rule_Name_Sequence (Whitespace_Sequence _opt_whitespace_sequence_1, Rule_Name _rule_name_1, Rule_Name_Sequence _self_rule_name_sequence)
        {
            // set values
            opt_whitespace_sequence_1 = _opt_whitespace_sequence_1;
            rule_name_1 = _rule_name_1;            
            self_rule_name_sequence = _self_rule_name_sequence;
            // add to dictionary
            Add(opt_whitespace_sequence_1);
            Add(rule_name_1);            
            Add(self_rule_name_sequence);

            // set properties
            UpdateProperties("Rule-Name-Sequence", RecursiveProperty.Right);
        }

        public Rule_Name_Sequence(Whitespace_Sequence _opt_whitespace_sequence_1, Pipe _pipe_1, Whitespace_Sequence _opt_whitespace_sequence_2, Rule_Name _rule_name_1, Rule_Name_Sequence _self_rule_name_sequence = null)
        {
            // set values 
            opt_whitespace_sequence_1 = _opt_whitespace_sequence_1;
            pipe_1 = _pipe_1;
            opt_whitespace_sequence_2 = _opt_whitespace_sequence_2;
            rule_name_1 = _rule_name_1;
            self_rule_name_sequence = _self_rule_name_sequence;

            // add to dictionary
            Add(opt_whitespace_sequence_1);
            Add(pipe_1);            
            Add(opt_whitespace_sequence_2);
            Add(rule_name_1);
            Add(self_rule_name_sequence);


            // set properties
            UpdateProperties("Rule-Name-Sequence", RecursiveProperty.Right);

        }
    }
}
