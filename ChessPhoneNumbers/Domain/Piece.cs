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
        public Vertex<Key> Position { get; private set; }

        public abstract IEnumerable<Edge<Key>> GetPossibleMoves();

        public void MoveTo(Vertex<Key> newPosition)
        {
            Position = newPosition;
        }
    }
}
