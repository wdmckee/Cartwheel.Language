using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Optional : Atom
    {

        public Optional(Token data)
        {
           this.Init(data, new string[] { "?" }, "Optional");
        }

    }
}
