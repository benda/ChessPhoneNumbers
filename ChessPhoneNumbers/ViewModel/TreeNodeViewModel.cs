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
    public class TreeNodeViewModel
    {
       // public ChessPhoneNumbers.Trees.TreeNode<Key> Node { get; }

        public TreeNodeViewModel(TreeNode<Key> node)
        {
            //Node = node;
        }
    }
}
