using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessPhoneNumbers.Domain;

namespace ChessPhoneNumbers.Trees
{
    class TreeNode<T>
    {
        public T Item { get; }

        public TreeNode(T item)
        {
            Item = item;
        }

        public HashSet<TreeNode<T>> Children { get; } = new HashSet<TreeNode<T>>();

        internal TreeNode<T> AddChild(T item)
        {
            TreeNode<T> child = new TreeNode<T>(item);
            Children.Add(child);
            return child;
        }

        public override string ToString()
        {
            return $"{Item}";
        }
    }
}
