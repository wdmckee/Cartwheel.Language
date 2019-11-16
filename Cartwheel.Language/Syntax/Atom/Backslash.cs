using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Backslash : Atom
    {

        public Backslash(Token data)
        {
            this.Init(data, new string[] { "\\" }, "Backslash");
        }


    }
}
