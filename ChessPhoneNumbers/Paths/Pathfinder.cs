using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.Trees;
using System.Collections.Generic;
using System.Linq;

namespace ChessPhoneNumbers.Paths
{
    class Pathfinder
    {
        private Keypad _keypad;
        private Dictionary<Key, Tree<Key>> _uniquePaths = new Dictionary<Key, Tree<Key>>();

        public Pathfinder(Keypad keypad)
        {
            _keypad = keypad;
        }

        public PathFinderResult FindAllPaths(Piece piece, IPathValidator<Key> validator)
        {
            List<Path> paths = new List<Path>();

            foreach (var startPosition in _keypad.Graph.Vertices)
            {
                if (!startPosition.Item.IsCharacter)
                {
                    var tree = new Tree<Key>(startPosition.Item);
                    _uniquePaths.Add(tree.Root.Item, tree);

                    piece.MoveTo(startPosition);

                    BuildPathsTree(piece, validator, _uniquePaths[startPosition.Item].Root, 1);

                    if (validator.IsValid(tree))
                    {
                        paths.AddRange(BuildAllPathsForStartPosition(piece, startPosition.Item));
                    }
                }
            }

            return new PathFinderResult(paths, (from t in _uniquePaths.Values where validator.IsValid(t) select t));
        }

        private List<Path> BuildAllPathsForStartPosition(Piece piece, Key startPosition)
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

        private void BuildPathsTree(Piece piece, IPathValidator<Key> validator, TreeNode<Key> currentPosition, int currentDepth)
        {
            if(!validator.IsValid(currentPosition,currentDepth))
            {
                return;
            }

            var moves = piece.GetPossibleMoves();
            foreach(var move in moves)
            {
                piece.MoveTo(move);
                var destinationChildTreeNode = currentPosition.AddChild(move.Item);
                BuildPathsTree(piece, validator, destinationChildTreeNode, currentDepth + 1);
            }
        }
    }
}
