using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Dash : Atom
    {

        public Dash(Token data)
        {
           this.Init(data, new string[] { "-" }, "Dash");
        }

    }
}
