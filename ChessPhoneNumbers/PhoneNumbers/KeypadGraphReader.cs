using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Graphs
{
    class KeypadGraphReader
    {
        public Keypad Read(String resourceName)
        {
            Graph<Key> graph = new Graph<Key>();
            Dictionary<int, Vertex<Key>> vertices = new Dictionary<int, Vertex<Key>>();

            foreach(string edgeString in new ResourceReader().Get(resourceName).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                int vertexAKey = int.Parse(edgeString[0].ToString());
                int vertexBKey = int.Parse(edgeString[4].ToString());

                if (!vertices.ContainsKey(vertexAKey))
                {
                    vertices.Add(vertexAKey, new Vertex<Key>(new Key(vertexAKey)));
                }

                if (!vertices.ContainsKey(vertexBKey))
                {
                    vertices.Add(vertexBKey, new Vertex<Key>(new Key(vertexBKey)));
                }

                var vertexA = vertices[vertexAKey];
                var vertexB = vertices[vertexBKey];

                Edge<Key> edge = new Edge<Key>(vertexA, vertexB, ToEdgeType(edgeString[2]));

                vertexA.Edges.AddLast(edge);
                vertexB.Edges.AddLast(edge);
            }

            foreach(int vertex in vertices.Keys)
            {
                graph.Vertices.Add(vertices[vertex]);
            }

            return new Keypad(graph); 
        }

        private EdgeType ToEdgeType(char v)
        {
            if (v == 'H') return EdgeType.Horizontal;
            if (v == 'V') return EdgeType.Vertical;
            if (v == 'D') return EdgeType.Diagonal;

            throw new InvalidOperationException($"Unknown edge type: {v}");
        }
    }
}
