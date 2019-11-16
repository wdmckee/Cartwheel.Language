using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Semi_Colon : Atom
    {

        public Semi_Colon(Token data)
        {
            this.Init(data, new string[] { ";" }, "Semi-Colon");
        }


    }
}
