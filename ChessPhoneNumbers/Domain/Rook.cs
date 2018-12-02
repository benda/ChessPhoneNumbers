using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessPhoneNumbers.Graphs;

namespace ChessPhoneNumbers.Domain
{
    class Rook : Piece
    {
        protected override bool IsAcceptableEdge(Edge<Key> edge)
        {
            return !edge.Direction.IsDiagonal;
        }

        protected override int? MaximumCostPerMove => null;
    }
}
