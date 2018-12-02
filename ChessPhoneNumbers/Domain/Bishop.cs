using ChessPhoneNumbers.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    class Bishop : Piece
    {
        protected override bool IsAcceptableEdge(Edge<Key> edge)
        {
            return edge.Direction.IsDiagonal;
        }

        protected override int? MaximumCostPerMove {  get { return null; } }
    }
}
