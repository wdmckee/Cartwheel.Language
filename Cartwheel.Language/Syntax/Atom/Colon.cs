using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Colon : Atom
    {

        public Colon(Token data)
        {
            this.Init(data, new string[] { ":" }, "Colon");
        }


    }
}
