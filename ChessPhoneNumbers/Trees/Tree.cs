using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Trees
{
    class Tree<T>
    {
        public TreeNode<T> Root { get; }

        public Tree(T root)
        {
            Root = new TreeNode<T>(root);
        }
    }
}
