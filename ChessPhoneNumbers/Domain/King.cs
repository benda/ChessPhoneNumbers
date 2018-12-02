using ChessPhoneNumbers.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    class King : Piece
    {
        protected override bool IsAcceptableEdge(Edge<Key> edge)
        {
            return true;
        }

        protected override int? MaximumCostPerMove => 1;
    }
}
