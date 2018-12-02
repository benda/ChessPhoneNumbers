using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Paths
{
    interface IPathValidator<T>
    {
        bool IsValid(TreeNode<T> currentPosition, int currentDepth);
        bool IsValid(Tree<Key> tree);
    }
}
