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
            throw new NotImplementedException();
        }

        protected override int? MaximumCostPerMove => null;
    }
}
