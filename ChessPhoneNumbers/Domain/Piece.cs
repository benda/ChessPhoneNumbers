using ChessPhoneNumbers.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    abstract class Piece
    {
        public Vertex<Key> Position { get; set; }

        public abstract IEnumerable<Edge<Key>> GetNextPotentialMoves();
    }
}
