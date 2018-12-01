using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    class Key
    {
        public int? Digit { get; }
        public char? Character { get; }

        public Key(int digit)
        {
            Digit = digit;
        }

        public Key(char character)
        {
            Character = character;
        }

        public bool IsValue(int value)
        {
            return Digit == value;
        }        

        public bool IsCharacter {  get { return Character != null; } }
    }
}
