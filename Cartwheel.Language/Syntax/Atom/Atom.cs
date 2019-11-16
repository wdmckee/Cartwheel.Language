using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Atom : Syntax
    {

        public void Init(Token data, string[] Chars, string Name)
        {

            foreach (string Char in Chars)  // this loop emulates an "OR"
            {
                if (data.StringValue.Equals(Char))
                {
                    Token = data;
                    ExpressionFragment = data.StringValue;
                    BeginIndex = data.Index;
                    EndIndex = data.Index;
                    ObjectName = Name;
                    Id = Guid.NewGuid();
                    IsValidated = true;
                    return;
                }
                else
                {
                    IsValidated = false;
                }
            }


        }

    }
}
