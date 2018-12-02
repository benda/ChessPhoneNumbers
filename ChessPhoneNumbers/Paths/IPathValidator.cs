using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Paths
{
    interface IPathValidator
    {
        bool IsValid(TreeNode<Key> currentPosition, int currentDepth);
    }
}
