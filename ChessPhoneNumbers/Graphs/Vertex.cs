using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Graphs
{
    [DebuggerDisplay("{Item}")]
    class Vertex<T>
    {
        public LinkedList<Edge<T>> Edges { get; } = new LinkedList<Edge<T>>();
        public T Item { get; }

        public Vertex(T item)
        {
            Item = item;
        }
    }
}
