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
        public static readonly Pieces Knight = new Pieces("Knight", new Knight());
        public static readonly Pieces Rook = new Pieces("Rook", new Rook());
        public static readonly Pieces Queen = new Pieces("Queen", new Queen());
        public static readonly Pieces King = new Pieces("King", new King());

        static Pieces() { }

        public Pieces(string name, Piece piece) : base(name)
        {
            Piece = piece;
        }

        public Piece Piece { get; }

        public static IEnumerable<Pieces> GetValues()
        {
            return GetValues<Pieces>();
        }
    }
}
