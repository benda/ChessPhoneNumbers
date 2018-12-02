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
        public override IEnumerable<Edge<Key>> GetPossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
}
