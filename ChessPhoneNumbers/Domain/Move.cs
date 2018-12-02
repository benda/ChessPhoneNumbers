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
        public Vertex<Key> Destination { get; }
        public Direction Direction { get; }
        public int Cost { get; set; }

        public Move(Vertex<Key> destination, Direction direction, int cost)
        {
            Destination = destination;
            Direction = direction;
        }
    }
}
