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
                string[] edgeInfo = edgeString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int vertexAKey = int.Parse(edgeInfo[0].ToString());
                int vertexBKey = int.Parse(edgeInfo[2].ToString());

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

                Edge<Key> edge = new Edge<Key>(vertexA, vertexB, Direction.FromString(edgeInfo[1]));

                vertexA.Edges.Add(edge);
                vertexB.Edges.Add(edge);
            }

            foreach(int vertex in vertices.Keys)
            {
                graph.Vertices.Add(vertices[vertex]);
            }

            return new Keypad(graph); 
        }
    }
}
