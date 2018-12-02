using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Graphs
{
    class Edge<T>
    {
        public Vertex<T> Origin { get; }
        public Vertex<T> Destination { get; }
        public Direction Direction { get; }
        public int Cost { get; } = 1;

        public Edge(Vertex<T> origin, Vertex<T> destination, Direction direction)
        {
            Origin = origin;
            Destination = destination;
            Direction = direction;
        }

        public override string ToString()
        {
            return $"{Origin} {Direction} {Destination}"; 
        }
    }
}
