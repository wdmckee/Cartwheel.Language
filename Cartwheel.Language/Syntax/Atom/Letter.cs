using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Letter : Atom
    {
        public Letter(Token data)
        {
            this.Init(data, 
                new string[] { "a","b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                               "A", "B", "C" , "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
                , "Letter");
        }
   



    }
}
