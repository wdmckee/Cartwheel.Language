using Cartwheel.Language;

using System;

namespace Cartwheel.Language
{
    public class Parser
    {

        #region ENTRY STUFF (separating for later)
        private ScanResult _scanResult = new ScanResult();
        //private ParseResult _parseResult { get; set; } = new ParseResult();

        public Parser(ref ScanResult scanresult)
        {
            _scanResult = scanresult;
        }


        public ParseResult Parse()
        {
            Syntax result = Parse_Production_Rule_Sequence(); 
            //result.Add(result);
            ParseResult _parseResult = new ParseResult(result);

            //return _parseResult;
            return _parseResult; // this should not be cast in prod. We need to finish "SetResult"
        }
        #endregion


        #region STANDARD

        private Production_Rule Parse_Production_Rule()
        {



            var _backtrack = _scanResult.CurrentReadIndex;
            Production_Rule _self = null;

            var _production_name = Parse_Production_Name(); ;
            var _opt_whitespace_sequence_1 = Parse_Whitespace_Sequence();
            var _rule_name_sequence = Parse_Rule_Name_Sequence();
            var _opt_whitespace_sequence_2 = Parse_Whitespace_Sequence();
            var _semi_colon = Parse_Semi_Colon();
            var _opt_whitespace_sequence_3 = Parse_Whitespace_Sequence();

            if (_production_name != null && _rule_name_sequence != null && _semi_colon != null)
            {
                _self = new Production_Rule(_production_name, _opt_whitespace_sequence_1, _rule_name_sequence, _opt_whitespace_sequence_2, _semi_colon, _opt_whitespace_sequence_3);
            }
            else { _self = null; }


            UpdateBacktrackIndex(_self, _backtrack);


            return _self;

        }
            // Create Parse_Production_Rule_1 here for consistency sake

        private Rule_Name Parse_Rule_Name()
        {
            var _backtrack = _scanResult.CurrentReadIndex;
            Rule_Name _self = null;

            _self = Parse_Rule_Name_1();
            if (_self != null) { return _self; }

            _self = Parse_Rule_Name_2();
            if (_self != null) { return _self; }

            UpdateBacktrackIndex(_self, _backtrack);
            return _self;

        }
            private Rule_Name Parse_Rule_Name_1()
        {



            var _backtrack = _scanResult.CurrentReadIndex;
            Rule_Name _self = null;

            var _Valid_Letter_Sequence = Parse_Valid_Letter_Sequence(); ;
            var _optional = Parse_Optional();

            if (_Valid_Letter_Sequence != null)
            {
                _self = new Rule_Name(_Valid_Letter_Sequence, _optional);
            }
            else { _self = null; }


            UpdateBacktrackIndex(_self, _backtrack);


            return _self;
            
        }
            private Rule_Name Parse_Rule_Name_2()
        {



            var _backtrack = _scanResult.CurrentReadIndex;
            Rule_Name _self = null;

            var _char_litteral = Parse_Char_Litteral(); ;
            var _optional = Parse_Optional();

            if (_char_litteral != null)
            {
                _self = new Rule_Name(_char_litteral);
            }
            else { _self = null; }


            UpdateBacktrackIndex(_self, _backtrack);


            return _self;

        }
        private Production_Name Parse_Production_Name()
        {



            var _backtrack = _scanResult.CurrentReadIndex;
            Production_Name _self = null;

            var _Valid_Letter_Sequence = Parse_Valid_Letter_Sequence(); ;
            var _colon = Parse_Colon();

            if (_Valid_Letter_Sequence != null)
            {
                _self = new Production_Name(_Valid_Letter_Sequence, _colon);
            }
            else { _self = null; }


            UpdateBacktrackIndex(_self, _backtrack);


            return _self;

        }
            // Create Parse_Production_Rule_1 here for consistency sake

        private Atomic_Symbol Parse_Atomic_Symbol()
        {
            var _backtrack = _scanResult.CurrentReadIndex;
            Atomic_Symbol _self = null;

            _self = Parse_Atomic_Symbol_1();
            if (_self != null) { return _self; }

            _self = Parse_Atomic_Symbol_2();
            if (_self != null) { return _self; }

            _self = Parse_Atomic_Symbol_3();
            if (_self != null) { return _self; }

            _self = Parse_Atomic_Symbol_4();
            if (_self != null) { return _self; }

            _self = Parse_Atomic_Symbol_5();
            if (_self != null) { return _self; }

            _self = Parse_Atomic_Symbol_6();
            if (_self != null) { return _self; }

            _self = Parse_Atomic_Symbol_7();
            if (_self != null) { return _self; }

            _self = Parse_Atomic_Symbol_8();
            if (_self != null) { return _self; }

            _self = Parse_Atomic_Symbol_9();
            if (_self != null) { return _self; }

            _self = Parse_Atomic_Symbol_10();
            if (_self != null) { return _self; }

            UpdateBacktrackIndex(_self, _backtrack);
            return _self;

        }
            private Atomic_Symbol Parse_Atomic_Symbol_1()
            {



                var _backtrack = _scanResult.CurrentReadIndex;
                Atomic_Symbol _self = null;

                var _dash = Parse_Dash(); ;

                if (_dash != null)
                {
                    _self = new Atomic_Symbol(_dash);
                }
                else { _self = null; }


                UpdateBacktrackIndex(_self, _backtrack);


                return _self;

            }
            private Atomic_Symbol Parse_Atomic_Symbol_2()
            {



                var _backtrack = _scanResult.CurrentReadIndex;
                Atomic_Symbol _self = null;

                var _colon = Parse_Colon(); ;

                if (_colon != null)
                {
                    _self = new Atomic_Symbol(_colon);
                }
                else { _self = null; }


                UpdateBacktrackIndex(_self, _backtrack);


                return _self;

            }
            private Atomic_Symbol Parse_Atomic_Symbol_3()
            {



                var _backtrack = _scanResult.CurrentReadIndex;
                Atomic_Symbol _self = null;

                var _optional = Parse_Optional(); ;

                if (_optional != null)
                {
                    _self = new Atomic_Symbol(_optional);
                }
                else { _self = null; }


                UpdateBacktrackIndex(_self, _backtrack);


                return _self;

            }
            private Atomic_Symbol Parse_Atomic_Symbol_4()
            {



                var _backtrack = _scanResult.CurrentReadIndex;
                Atomic_Symbol _self = null;

                var _pipe = Parse_Pipe(); ;

                if (_pipe != null)
                {
                    _self = new Atomic_Symbol(_pipe);
                }
                else { _self = null; }


                UpdateBacktrackIndex(_self, _backtrack);


                return _self;

            }
            private Atomic_Symbol Parse_Atomic_Symbol_5()
            {



                var _backtrack = _scanResult.CurrentReadIndex;
                Atomic_Symbol _self = null;

                var _whitespace = Parse_Whitespace(); ;

                if (_whitespace != null)
                {
                    _self = new Atomic_Symbol(_whitespace);
                }
                else { _self = null; }


                UpdateBacktrackIndex(_self, _backtrack);


                return _self;

            }
            private Atomic_Symbol Parse_Atomic_Symbol_6()
            {



                var _backtrack = _scanResult.CurrentReadIndex;
                Atomic_Symbol _self = null;

                var _double_quote = Parse_Double_Quote(); ;

                if (_double_quote != null)
                {
                    _self = new Atomic_Symbol(_double_quote);
                }
                else { _self = null; }


                UpdateBacktrackIndex(_self, _backtrack);


                return _self;

            }
            private Atomic_Symbol Parse_Atomic_Symbol_7()
            {



                var _backtrack = _scanResult.CurrentReadIndex;
                Atomic_Symbol _self = null;

                var _backslash = Parse_Backslash(); ;

                if (_backslash != null)
                {
                    _self = new Atomic_Symbol(_backslash);
                }
                else { _self = null; }


                UpdateBacktrackIndex(_self, _backtrack);


                return _self;

            }
            private Atomic_Symbol Parse_Atomic_Symbol_8()
            {



                var _backtrack = _scanResult.CurrentReadIndex;
                Atomic_Symbol _self = null;

                var _letter = Parse_Letter(); ;

                if (_letter != null)
                {
                    _self = new Atomic_Symbol(_letter);
                }
                else { _self = null; }


                UpdateBacktrackIndex(_self, _backtrack);


                return _self;

            }
            private Atomic_Symbol Parse_Atomic_Symbol_9()
        {



            var _backtrack = _scanResult.CurrentReadIndex;
            Atomic_Symbol _self = null;

            var _semi_colon = Parse_Semi_Colon(); ;

            if (_semi_colon != null)
            {
                _self = new Atomic_Symbol(_semi_colon);
            }
            else { _self = null; }


            UpdateBacktrackIndex(_self, _backtrack);


            return _self;

        }
            private Atomic_Symbol Parse_Atomic_Symbol_10()
        {



            var _backtrack = _scanResult.CurrentReadIndex;
            Atomic_Symbol _self = null;

            var _single_quote = Parse_Single_Quote(); ;

            if (_single_quote != null)
            {
                _self = new Atomic_Symbol(_single_quote);
            }
            else { _self = null; }


            UpdateBacktrackIndex(_self, _backtrack);


            return _self;

        }

        private Char_Litteral Parse_Char_Litteral()
        {
            var _backtrack = _scanResult.CurrentReadIndex;
            Char_Litteral _self = null;

            _self = Parse_Char_Litteral_1();
            if (_self != null) { return _self; }

            UpdateBacktrackIndex(_self, _backtrack);
            return _self;

        }
            private Char_Litteral Parse_Char_Litteral_1()
        {



            var _backtrack = _scanResult.CurrentReadIndex;
            Char_Litteral _self = null;

            var opt_whitespace_sequence_1 = Parse_Whitespace_Sequence();
            var single_quote_1 = Parse_Single_Quote();
            var atomic_symbol = Parse_Atomic_Symbol();
            var single_quote_2 = Parse_Single_Quote();
            var opt_whitespace_sequence_2 = Parse_Whitespace_Sequence();

            if (single_quote_1 != null && atomic_symbol != null && single_quote_2 != null)
            {
                _self = new Char_Litteral(opt_whitespace_sequence_1, single_quote_1, atomic_symbol, single_quote_2, opt_whitespace_sequence_2);
            }
            else { _self = null; }


            UpdateBacktrackIndex(_self, _backtrack);


            return _self;

        }

        #endregion


        #region SEQUENCE

        #region Letter-Sequence
        private Valid_Letter_Sequence Parse_Valid_Letter_Sequence(Valid_Letter_Sequence _self = null)
        {

            var _backtrack = _scanResult.CurrentReadIndex;

            var _Valid_Letter_Sequence_1 = Parse_Valid_Letter_Sequence_1(_self);
            if (_Valid_Letter_Sequence_1 != null) { _self = Parse_Valid_Letter_Sequence(_Valid_Letter_Sequence_1); }

            var _Valid_Letter_Sequence_2 = Parse_Valid_Letter_Sequence_2(_self);
            if (_Valid_Letter_Sequence_2 != null) { _self = Parse_Valid_Letter_Sequence(_Valid_Letter_Sequence_2); }

            var _Valid_Letter_Sequence_3 = Parse_Valid_Letter_Sequence_3(_self);
            if (_Valid_Letter_Sequence_3 != null) { _self = Parse_Valid_Letter_Sequence(_Valid_Letter_Sequence_3); }

            UpdateBacktrackIndex(_self, _backtrack);


            return _self;


        }
            private Valid_Letter_Sequence Parse_Valid_Letter_Sequence_1(Valid_Letter_Sequence _self = null)
            {
                //"a-b"
                var _backtrack = _scanResult.CurrentReadIndex;

                var _letter_1 = Parse_Letter();
                var _dash = Parse_Dash();
                var _letter_2 = Parse_Letter();

                if (_letter_1 != null && _dash != null && _letter_2 != null)
                {
                    _self = new Valid_Letter_Sequence(_letter_1, _dash, _letter_2, _self);
                }
                else { _self = null; }

                UpdateBacktrackIndex(_self, _backtrack);


                return _self;
            }
            private Valid_Letter_Sequence Parse_Valid_Letter_Sequence_2(Valid_Letter_Sequence _self = null)
            {
                //"a-b"
                var _backtrack = _scanResult.CurrentReadIndex;

                var _letter_1 = Parse_Letter();  
     

                if (_letter_1 != null)
                {
                    _self = new Valid_Letter_Sequence(_letter_1, _self);
                }
                else { _self = null; }

                UpdateBacktrackIndex(_self, _backtrack);


                return _self;
            }
            private Valid_Letter_Sequence Parse_Valid_Letter_Sequence_3(Valid_Letter_Sequence _self = null)
            {
                //"a-b"
                var _backtrack = _scanResult.CurrentReadIndex;

                var _dash = Parse_Dash();
                var _letter_1 = Parse_Letter();            

                if (_letter_1 != null && _dash != null && _self != null) // _self flag is set due to no optional
                {
                    _self = new Valid_Letter_Sequence(_letter_1, _dash,  _self);
                }
                else { _self = null; }

                UpdateBacktrackIndex(_self, _backtrack);


                return _self;
            }
        #endregion

        #region Whitespace-Sequence
        private Whitespace_Sequence Parse_Whitespace_Sequence(Whitespace_Sequence _self = null)
        {

            var _backtrack = _scanResult.CurrentReadIndex;

            var _whitespace_sequence_1 = Parse_Whitespace_Sequence_1(_self);
            if (_whitespace_sequence_1 != null ) { _self = Parse_Whitespace_Sequence(_whitespace_sequence_1); }

            UpdateBacktrackIndex(_self, _backtrack);


            return _self;


        }
            private Whitespace_Sequence Parse_Whitespace_Sequence_1(Whitespace_Sequence _self = null)
        {
            //"   "
            var _backtrack = _scanResult.CurrentReadIndex;

            var _whitespace_1 = Parse_Whitespace();

            if (_whitespace_1 != null)
            {
                _self = new Whitespace_Sequence(_whitespace_1,  _self);
            }
            else { _self = null; }

            UpdateBacktrackIndex(_self, _backtrack);


            return _self;
        }
        #endregion

        #region Rule-Name-Sequence
        private Rule_Name_Sequence Parse_Rule_Name_Sequence(Rule_Name_Sequence _self = null)
        {

            var _backtrack = _scanResult.CurrentReadIndex;

            var _rule_name_sequence_1 = Parse_Rule_Name_Sequence_1(_self);
            if (_rule_name_sequence_1 != null) { _self = Parse_Rule_Name_Sequence(_rule_name_sequence_1); }

            var _rule_name_sequence_2 = Parse_Rule_Name_Sequence_2(_self);
            if (_rule_name_sequence_2 != null)  { _self = Parse_Rule_Name_Sequence(_rule_name_sequence_2); } // non-recursive

            var _rule_name_sequence_3 = Parse_Rule_Name_Sequence_3(_self);
            if (_rule_name_sequence_3 != null) { _self = Parse_Rule_Name_Sequence(_rule_name_sequence_3); }

            UpdateBacktrackIndex(_self, _backtrack);


            return _self;


        }
        private Rule_Name_Sequence Parse_Rule_Name_Sequence_1(Rule_Name_Sequence _self = null)
        {
            //"   "
            var _backtrack = _scanResult.CurrentReadIndex;

            var rule_name_1 = Parse_Rule_Name();
            var opt_whitespace_sequence_1 = Parse_Whitespace_Sequence();
            var pipe_1 = Parse_Pipe();
            var opt_whitespace_sequence_2 = Parse_Whitespace_Sequence();
            var rule_name_2 = Parse_Rule_Name();

            if (rule_name_1 != null && pipe_1 != null && rule_name_2 != null)
            {
                _self = new Rule_Name_Sequence(rule_name_1, opt_whitespace_sequence_1, pipe_1, opt_whitespace_sequence_2, rule_name_2, _self);
            }
            else { _self = null; }

            UpdateBacktrackIndex(_self, _backtrack);


            return _self;
        }
        private Rule_Name_Sequence Parse_Rule_Name_Sequence_2(Rule_Name_Sequence _self = null)
        {
            //"   "
            var _backtrack = _scanResult.CurrentReadIndex;

            var opt_whitespace_sequence_1 = Parse_Whitespace_Sequence();
            var rule_name_1 = Parse_Rule_Name();
            

            if (rule_name_1 != null)// && _self ==null
            {
                _self = new Rule_Name_Sequence(opt_whitespace_sequence_1,rule_name_1, _self);
            }
            else { _self = null; }

            UpdateBacktrackIndex(_self, _backtrack);


            return _self;
        }
        private Rule_Name_Sequence Parse_Rule_Name_Sequence_3(Rule_Name_Sequence _self = null)
        {
            var _backtrack = _scanResult.CurrentReadIndex;

            var opt_whitespace_sequence_1 = Parse_Whitespace_Sequence();
            var pipe_1 = Parse_Pipe();
            var opt_whitespace_sequence_2 = Parse_Whitespace_Sequence();
            var rule_name_1 = Parse_Rule_Name();

            if (pipe_1 != null && rule_name_1 != null && _self !=null)
            {
                _self = new Rule_Name_Sequence(opt_whitespace_sequence_1,pipe_1, opt_whitespace_sequence_2,  rule_name_1, _self);
            }
            else { _self = null; }

            UpdateBacktrackIndex(_self, _backtrack);

            return _self;
        }
        #endregion

        #region Production-Rule-Sequence
        private Production_Rule_Sequence Parse_Production_Rule_Sequence(Production_Rule_Sequence _self = null)
        {
            var _backtrack = _scanResult.CurrentReadIndex;

            var _production_rule_sequence_1 = Parse_Production_Rule_Sequence_1(_self);
            if (_production_rule_sequence_1 != null) { _self = Parse_Production_Rule_Sequence(_production_rule_sequence_1); }

            //var _production_rule_sequence_2 = Parse_Production_Rule_Sequence_2(_self);
            //if (_production_rule_sequence_2 != null) { _self = Parse_Production_Rule_Sequence(_production_rule_sequence_2); }

            UpdateBacktrackIndex(_self, _backtrack);
            
            return _self;
        }
        private Production_Rule_Sequence Parse_Production_Rule_Sequence_1(Production_Rule_Sequence _self = null)
        {
            var _backtrack = _scanResult.CurrentReadIndex;

            var opt_whitespace_sequence_1 = Parse_Whitespace_Sequence();
            var production_rule = Parse_Production_Rule();            


            if (production_rule != null) //&& _self != null
            {
                _self = new Production_Rule_Sequence(opt_whitespace_sequence_1,production_rule,  _self);
            }
            else { _self = null; }

            UpdateBacktrackIndex(_self, _backtrack);

            return _self;
        }
        private Production_Rule_Sequence Parse_Production_Rule_Sequence_2(Production_Rule_Sequence _self = null)
        {
            var _backtrack = _scanResult.CurrentReadIndex;

            var production_rule = Parse_Production_Rule();
            var opt_whitespace_sequence_1 = Parse_Whitespace_Sequence();


            if (production_rule != null)
            {
                _self = new Production_Rule_Sequence(production_rule, _self);
            }
            else { _self = null; }

            UpdateBacktrackIndex(_self, _backtrack);

            return _self;
        }
        #endregion




        #endregion


        #region ATOM

        private Backslash Parse_Backslash()
        {
            /* dash:
                "-" */

            if (_scanResult.IsEOL) { return null; } // must be first line on any atom

            var _data = _scanResult.CurrentToken;
            var _result = new Backslash(_data);

            if (_result.IsValidated)
            {
                _scanResult.CurrentReadIndex++;
                return _result;
            }
            else
            {
                return null;
            }
        }
        private Colon Parse_Colon()
        {
            /* colon:
                ":" */

            if (_scanResult.IsEOL) { return null; } // must be first line on any atom

            var _data = _scanResult.CurrentToken;
            var _result = new Colon(_data);

            if (_result.IsValidated)
            {
                _scanResult.CurrentReadIndex++;
                return _result;
            }
            else
            {
                return null;
            }
        }
        private Dash Parse_Dash()
        {
            /* dash:
                "-" */

            if (_scanResult.IsEOL) { return null; } // must be first line on any atom

            var _data = _scanResult.CurrentToken;
            var _result = new Dash(_data);

            if (_result.IsValidated)
            {
                _scanResult.CurrentReadIndex++;
                return _result;
            }
            else
            {
                return null;
            }
        }
        private Double_Quote Parse_Double_Quote()
        {
 
            if (_scanResult.IsEOL) { return null; } // must be first line on any atom

            var _data = _scanResult.CurrentToken;
            var _result = new Double_Quote(_data);

            if (_result.IsValidated)
            {
                _scanResult.CurrentReadIndex++;
                return _result;
            }
            else
            {
                return null;
            }
        }
        private Letter Parse_Letter()
        {
            /* letter:
                "a-z[A-Z]" */

            if (_scanResult.IsEOL) { return null; } // must be first line on any atom

            var _data = _scanResult.CurrentToken;
            var _result = new Letter(_data);

            if (_result.IsValidated)
            {
                _scanResult.CurrentReadIndex++;
                return _result;
            }
            else
            {
                return null;
            }
        }
        private Optional Parse_Optional()
        {
            /* optional:
                "?" */

            if (_scanResult.IsEOL) { return null; } // must be first line on any atom

            var _data = _scanResult.CurrentToken;
            var _result = new Optional(_data);

            if (_result.IsValidated)
            {
                _scanResult.CurrentReadIndex++;
                return _result;
            }
            else
            {
                return null;
            }
        }
        private Pipe Parse_Pipe()
        {
            /* pipe:
                "|" */

            if (_scanResult.IsEOL) { return null; } // must be first line on any atom

            var _data = _scanResult.CurrentToken;
            var _result = new Pipe(_data);

            if (_result.IsValidated)
            {
                _scanResult.CurrentReadIndex++;
                return _result;
            }
            else
            {
                return null;
            }
        }
        private Semi_Colon Parse_Semi_Colon()
        {
            /* semi-colon:
                ";" */

            if (_scanResult.IsEOL) { return null; } // must be first line on any atom

            var _data = _scanResult.CurrentToken;
            var _result = new Semi_Colon(_data);

            if (_result.IsValidated)
            {
                _scanResult.CurrentReadIndex++;
                return _result;
            }
            else
            {
                return null;
            }
        }
        private Single_Quote Parse_Single_Quote()
        {
            /* single-quote:
                "'" */

            if (_scanResult.IsEOL) { return null; } // must be first line on any atom

            var _data = _scanResult.CurrentToken;
            var _result = new Single_Quote(_data);

            if (_result.IsValidated)
            {
                _scanResult.CurrentReadIndex++;
                return _result;
            }
            else
            {
                return null;
            }
        }  
        private Whitespace Parse_Whitespace()
        {
            /* whitespace:
                " " */

            if (_scanResult.IsEOL) { return null; } // must be first line on any atom

            var _data = _scanResult.CurrentToken;
            var _result = new Whitespace(_data);

            if (_result.IsValidated)
            {
                _scanResult.CurrentReadIndex++;
                return _result;
            }
            else
            {
                return null;
            }
        }
        #endregion


        public void UpdateBacktrackIndex(dynamic _self, int _backtrack)
        {
            if (_self == null)
                if (_scanResult.CurrentReadIndex != _backtrack)
                    _scanResult.CurrentReadIndex = _backtrack;
        }

    }
}
