using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessPhoneNumbers.Graphs;

namespace ChessPhoneNumbers.Domain
{
    class Pawn : Piece
    {
        public override IEnumerable<Edge<Key>> GetPossibleMoves()
        {
            return new List<Edge<Key>>(); //we know pawn has no valid phone number so no need to implement
        }
    }
}
