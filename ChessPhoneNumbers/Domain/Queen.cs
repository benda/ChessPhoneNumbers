using ChessPhoneNumbers.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    class Queen : Piece
    {
        public override IEnumerable<Vertex<Key>> GetNextPotentialMoves()
        {
            throw new NotImplementedException();
        }

    }
}
