using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public override bool Equals(object obj)
        {
            var key = obj as Key;
            return key != null &&
                   EqualityComparer<int?>.Default.Equals(Digit, key.Digit) &&
                   EqualityComparer<char?>.Default.Equals(Character, key.Character);
        }

        public override int GetHashCode()
        {
            var hashCode = -569536490;
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(Digit);
            hashCode = hashCode * -1521134295 + EqualityComparer<char?>.Default.GetHashCode(Character);
            return hashCode;
        }

        public bool IsCharacter { get { return Character != null; } }

        public override string ToString()
        {
            return $"{Digit} {Character}"; //    [DebuggerDisplay("{Digit} {Character}")] doesn't handle drilling down multiple levels
        }
    }
}
