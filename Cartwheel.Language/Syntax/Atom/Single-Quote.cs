using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Single_Quote : Atom
    {

        public Single_Quote(Token data)
        {
           this.Init(data, new string[] { "'" }, "Single-Quote");
            // the compile will output this char even though it actually appears as `' in code
        }

    }
}
