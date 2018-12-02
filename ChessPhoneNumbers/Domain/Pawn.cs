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
        protected override bool IsAcceptableEdge(Edge<Key> edge)
        {
            return false;
        }

        protected override int? MaximumCostPerMove => 1;
    }
}
