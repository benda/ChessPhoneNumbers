using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Graphs
{
    [DebuggerDisplay("{VertexA} {EdgeType} {VertexB}")]
    class Edge<T>
    {
        public Vertex<T> VertexA { get; }
        public Vertex<T> VertexB { get; }
        public EdgeType EdgeType { get; }
        public int Cost { get; } = 1;

        public Edge(Vertex<T> vertexA, Vertex<T> vertexB, EdgeType edgeType)
        {
            VertexA = vertexA;
            VertexB = vertexB;
            EdgeType = edgeType;
        }
    }
}
