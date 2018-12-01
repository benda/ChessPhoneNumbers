using ChessPhoneNumbers.TypeSafeEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    class Pieces : AbstractTypeSafeEnum
    {
        public static readonly Pieces Pawn = new Pieces("Pawn", new Pawn());
        public static readonly Pieces Bishop = new Pieces("Bishop", new Bishop());

        static Pieces() { }

        public Pieces(string name, Piece piece) : base(name)
        {
            Name = name;
            Piece = piece;
        }

        public string Name { get; }
        public Piece Piece { get; }

        public static IEnumerable<Pieces> GetValues()
        {
            return GetValues<Pieces>();
        }
    }
}
