using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Trees
{
    public class Tree<T>
    {
        public TreeNode<T> Root { get; }
        private List<TreeNode<T>> _allLeafNodes;

        public Tree(T root)
        {
            Root = new TreeNode<T>(root, null);
        }

        public List<TreeNode<T>> AllLeafNodes()
        {
            _allLeafNodes = new List<TreeNode<T>>();

            FindAllLeafNodes(Root);

            return _allLeafNodes;
        }

        private void FindAllLeafNodes(TreeNode<T> current)
        {
            if(current.Children.Count == 0)
            {
               _allLeafNodes.Add(current);
            }

            foreach(var node in current.Children)
            {
                FindAllLeafNodes(node);
            }
        }
    }
}
