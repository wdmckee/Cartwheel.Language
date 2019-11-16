using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Atomic_Symbol : Standard
    {

        
        public Backslash backslash;
        public Colon colon;
        public Dash dash;
        public Double_Quote double_quote;
        public Letter letter;
        public Optional optional;
        public Pipe pipe;        
        public Semi_Colon semi_colon;
        public Single_Quote single_quote;
        public Whitespace whitespace;


        public Atomic_Symbol(Backslash _backslash)
        {
            backslash = _backslash;
            Add(backslash);

            UpdateProperties("atomic-symbol");
        }

        public Atomic_Symbol(Colon _colon)
        {
            colon = _colon;
            Add(colon);

            UpdateProperties("atomic-symbol");
        }

        public Atomic_Symbol(Dash _dash)
        {
            dash = _dash;
            Add(dash);
            
            UpdateProperties("atomic-symbol");
        }

        public Atomic_Symbol(Double_Quote _double_quote)
        {
            double_quote = _double_quote;
            Add(double_quote);

            UpdateProperties("atomic-symbol");
        }

        public Atomic_Symbol(Letter _letter)
        {
            letter = _letter;
            Add(_letter);

            UpdateProperties("atomic-symbol");

        }

        public Atomic_Symbol(Optional _optional)
        {
            optional = _optional;
            Add(optional);

            UpdateProperties("atomic-symbol");
        }

        public Atomic_Symbol(Pipe _pipe)
        {
            pipe = _pipe;
            Add(pipe);

            UpdateProperties("atomic-symbol");
        }

        public Atomic_Symbol(Semi_Colon _semi_colon)
        {
            semi_colon = _semi_colon;
            Add(semi_colon);

            UpdateProperties("atomic-symbol");
        }

        public Atomic_Symbol(Single_Quote _single_quote)
        {
            single_quote = _single_quote;
            Add(single_quote);

            UpdateProperties("atomic-symbol");
        }
        
        public Atomic_Symbol(Whitespace _whitespace)
        {
            whitespace = _whitespace;
            Add(whitespace);

            UpdateProperties("atomic-symbol");
        }



       


        
    }
}
