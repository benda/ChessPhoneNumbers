using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Graphs
{
    class GraphReader
    {
        public Graph<Key> Read(String resourceName)
        {
            //TODO: read graph from file
            //            string graph = new ResourceReader().Get(resourceName);

            Graph<Key> graph = new Graph<Key>();
            graph.Vertices.Add(new Vertex<Key>(new Key(1)));


            return graph;
        }
    }
}
