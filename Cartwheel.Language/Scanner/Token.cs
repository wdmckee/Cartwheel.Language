using System;

namespace Cartwheel.Language
{
    public class Token
    {

        /*
         Value: stores a dynamic version of the data element at that index
         StringValue: stores a string representation of that value for parsing
         IsReserved: for future use
         Index: even if our Value is a string (char array), it still only has a single index in the token array
        */

        public dynamic Value { get; set; }
        public string StringValue { get; set; }
        public bool IsReserved { get; set; }
        public int Index { get; set; }


        public Token(dynamic data, int index)
        {
            Value = data;
            StringValue = data.ToString();
            IsReserved = false;
            Index = index;
        }


    }
}

