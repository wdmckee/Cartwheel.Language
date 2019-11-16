using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Double_Quote : Atom
    {

        public Double_Quote(Token data)
        {
           this.Init(data, new string[] { "\"" }, "Double-Quote");
        }

    }
}
