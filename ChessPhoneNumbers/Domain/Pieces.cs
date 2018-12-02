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
        public static readonly Pieces Knight = new Pieces("Knight", new Knight(), true);
        public static readonly Pieces Rook = new Pieces("Rook", new Rook());
        public static readonly Pieces Queen = new Pieces("Queen", new Queen(), true);
        public static readonly Pieces King = new Pieces("King", new King());

        static Pieces() { }

        public Pieces(string name, Piece piece, bool isLongRunning=false) : base(name)
        {
            Piece = piece;
            ImageUrl = $"pack://application:,,,/ChessPhoneNumbers;component/resources/{Value}.png";
            IsLongRunning = isLongRunning;
        }

        public Piece Piece { get; }
        public string ImageUrl { get; }
        public bool IsLongRunning { get; }
        public static IEnumerable<Pieces> GetValues()
        {
            return GetValues<Pieces>();
        }
    }
}
