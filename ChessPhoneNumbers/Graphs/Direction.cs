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
        public static readonly Direction North = new Direction("N", "S");
        public static readonly Direction NorthEast = new Direction("NE", "SW", true);
        public static readonly Direction East = new Direction("E","W");
        public static readonly Direction SouthEast = new Direction("SE","NW", true);
        public static readonly Direction South = new Direction("S","N");
        public static readonly Direction SouthWest = new Direction("SW","NE", true);
        public static readonly Direction West = new Direction("W","E");
        public static readonly Direction NorthWest = new Direction("NW","SE", true);

        static Direction() { }

        public Direction(string value, string opposite, bool isDiagonal=false) : base(value)
        {
            IsDiagonal = isDiagonal;
            _opposite = opposite;
        }      

        public bool IsDiagonal { get; }
        public Direction Opposite { get; private set; }
        private string _opposite;

        public static void Initialize()
        {
            foreach (Direction direction in GetValues())
            {
                direction.Opposite = FromString(direction._opposite);
            }
        }

        public static IEnumerable<Direction> GetValues()
        {
            return GetValues<Direction>();
        }

        public static Direction FromString(string s)
        {
            return FromString<Direction>(s);
        }
    }
}
