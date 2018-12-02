using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.Trees;

namespace ChessPhoneNumbers.ViewModel
{
    /// <summary>
    /// Generics in XAML don't work so well so we wrap 
    /// </summary>
    class TreeNodeViewModel
    {
        public List<TreeNodeViewModel> Children { get; } = new List<TreeNodeViewModel>();
        public Key Item { get; private set; }

        public TreeNodeViewModel() { }

        public TreeNodeViewModel(TreeNode<Key> node)
        {
            BuildTree(node);
        }

        private void BuildTree(TreeNode<Key> node)
        {
            Item = node.Item;
            foreach(var child in node.Children)
            {
                var childVm = new TreeNodeViewModel(child);
                Children.Add(childVm);
            }
        }
    }
}
