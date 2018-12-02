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
        public List<Edge<T>> Edges { get; } = new List<Edge<T>>();
        public T Item { get; }

        public Vertex(T item)
        {
            Item = item;
        }

        public override bool Equals(object obj)
        {
            var vertex = obj as Vertex<T>;
            return vertex != null &&
                   EqualityComparer<T>.Default.Equals(Item, vertex.Item);
        }

        public override int GetHashCode()
        {
            return -979861770 + EqualityComparer<T>.Default.GetHashCode(Item);
        }
    }
}
