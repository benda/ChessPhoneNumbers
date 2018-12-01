using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Graphs
{
    class Vertex<T>
    {
        public LinkedList<Vertex<T>> Neighbors { get; } = new LinkedList<Vertex<T>>();
        public T Item { get; }

        public Vertex(T t)
        {
            Item = t;
        }
    }
}
