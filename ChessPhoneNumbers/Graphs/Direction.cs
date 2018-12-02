using ChessPhoneNumbers.TypeSafeEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Graphs
{
    class Direction : AbstractTypeSafeEnum
    {
        public static readonly Direction North = new Direction("N");
        public static readonly Direction NorthEast = new Direction("NE",true);
        public static readonly Direction East = new Direction("E");
        public static readonly Direction SouthEast = new Direction("SE", true);
        public static readonly Direction South = new Direction("S");
        public static readonly Direction SouthWest = new Direction("SW", true);
        public static readonly Direction West = new Direction("W");
        public static readonly Direction NorthWest = new Direction("NW", true);

        static Direction() { }

        public Direction(string value, bool isDiagonal=false) : base(value)
        {
            IsDiagonal = isDiagonal;
        }      

        public bool IsDiagonal { get; }

        public static Direction FromString(string s)
        {
            return FromString<Direction>(s);
        }
    }
}
