using ChessPhoneNumbers.Trees;
using System.Collections.Generic;
using System.Linq;

namespace ChessPhoneNumbers.Domain
{
    class Pathfinder
    {
        private Keypad _keypad;
        private Dictionary<Key, Tree<Key>> _uniquePaths = new Dictionary<Key, Tree<Key>>();

        public Pathfinder(Keypad keypad)
        {
            _keypad = keypad;
        }

        public List<Path> FindAllPaths(Piece piece, int maximumNumberOfKeysInPath)
        {
            List<Path> paths = new List<Path>();

            foreach (var startPosition in _keypad.Graph.Vertices)
            {
                if (!startPosition.Item.IsCharacter)
                {
                    var tree = new Tree<Key>(startPosition.Item);
                    _uniquePaths.Add(tree.Root.Item, tree);

                    piece.MoveTo(startPosition);

                    BuildPathsTree(piece, maximumNumberOfKeysInPath, _uniquePaths[startPosition.Item].Root, 1);

                    paths.AddRange(BuildAllPathsForPosition(piece, maximumNumberOfKeysInPath, startPosition.Item));
                }
            }

            return paths;
        }

        private List<Path> BuildAllPathsForPosition(Piece piece, int maximumNumberOfKeysInPath, Key startPosition)
        {
            var pathsTree = _uniquePaths[startPosition];
            List<Path> allPaths = new List<Path>();

            foreach(var node in pathsTree.AllLeafNodes())
            {
                Path path = new Path();
                var current = node;
                while(current.Parent != null)
                {
                    path.Keys.AddFirst(current.Item);
                    current = current.Parent;
                }

                path.Keys.AddFirst(startPosition);
                allPaths.Add(path);
            }

            return allPaths;            
        }

        private void BuildPathsTree(Piece piece, int maximumNumberOfKeysInPath, TreeNode<Key> currentPosition, int currentDepth)
        {
            if(currentDepth == maximumNumberOfKeysInPath)
            {
                return;
            }

            var moves = piece.GetPossibleMoves();
            foreach(var move in moves)
            {
                piece.MoveTo(move.Destination);
                var destinationChildTreeNode = currentPosition.AddChild(move.Destination.Item);
                BuildPathsTree(piece, maximumNumberOfKeysInPath, destinationChildTreeNode, currentDepth + 1);
            }
        }
    }
}
