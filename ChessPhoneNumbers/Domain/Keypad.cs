using ChessPhoneNumbers.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    class Keypad
    {
        public Graph<Key> Graph { get; }

        public Keypad(Graph<Key> graph)
        {
            Graph = graph;
        }
    }
}
