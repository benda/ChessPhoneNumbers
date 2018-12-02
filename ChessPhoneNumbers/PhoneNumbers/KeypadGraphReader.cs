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
            Direction.Initialize();

            Graph<Key> graph = new Graph<Key>();
            Dictionary<int, Vertex<Key>> vertices = new Dictionary<int, Vertex<Key>>();
          
            foreach(string edgeString in new ResourceReader().Get(resourceName).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] edgeInfo = edgeString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int originVertexKey = int.Parse(edgeInfo[0].ToString());
                int destinationVertexKey = int.Parse(edgeInfo[2].ToString());

                if (!vertices.ContainsKey(originVertexKey))
                {
                    vertices.Add(originVertexKey, new Vertex<Key>(new Key(originVertexKey)));
                }

                if (!vertices.ContainsKey(destinationVertexKey))
                {
                    vertices.Add(destinationVertexKey, new Vertex<Key>(new Key(destinationVertexKey)));
                }

                var originVertex = vertices[originVertexKey];
                var destinationVertex = vertices[destinationVertexKey];

                Edge<Key> edge = new Edge<Key>(originVertex, destinationVertex, Direction.FromString(edgeInfo[1]));
             
                originVertex.Edges.Add(edge);
                destinationVertex.Edges.Add(new Edge<Key>(edge.Destination, edge.Origin, edge.Direction.Opposite));
            }

            foreach(int vertex in vertices.Keys)
            {
                graph.Vertices.Add(vertices[vertex]);
            }

            return new Keypad(graph); 
        }
    }
}
