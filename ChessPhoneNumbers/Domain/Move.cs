using ChessPhoneNumbers.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    class Move
    {
        public Vertex<Key> Origin { get; }
        public Vertex<Key> Destination { get; }
        public int Cost { get; }
        public List<Edge<Key>> Path { get; }

        public Move(Vertex<Key> destination, int cost, Vertex<Key> origin)
        {
            Destination = destination;
            Cost = cost;
            Origin = origin;
            Path = new List<Edge<Key>>();
        }
    }
}
