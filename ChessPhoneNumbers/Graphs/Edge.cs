using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Graphs
{
    [DebuggerDisplay("{Origin} {Direction} {Destination}")]
    class Edge<T>
    {
        public Vertex<T> Origin { get; }
        public Vertex<T> Destination { get; }
        public Direction Direction { get; }
        public int Cost { get; } = 1;

        public Edge(Vertex<T> vertexA, Vertex<T> vertexB, Direction direction)
        {
            Origin = vertexA;
            Destination = vertexB;
            Direction = direction;
        }
    }
}
