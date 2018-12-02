using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Trees
{
    class TreeNode<T>
    {
        public T Item { get; }

        public TreeNode(T item)
        {
            Item = item;
        }

        public List<T> Children { get; } = new List<T>();
    }
}
