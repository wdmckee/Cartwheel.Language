using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Whitespace : Atom
    {

        public Whitespace(Token data)
        {
           this.Init(data, new string[] { " ", "\r", "\n", "\t" }, "Whitespace");
        }

    }
}
