using ChessPhoneNumbers.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    class Knight : Piece
    {
        protected override bool IsAcceptableEdge(Edge<Key> edge)
        {
            return edge.Direction == Direction.North || edge.Direction == Direction.South || edge.Direction == Direction.East || edge.Direction == Direction.West;
        }

        protected override int? MaximumCostPerMove => 3;

        protected override bool IsAcceptableMove(Move m)
        {
            return true;
        }
    }
}
