using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Pipe : Atom
    {

        public Pipe(Token data)
        {
           this.Init(data, new string[] { "|" }, "Pipe");
        }

    }
}
