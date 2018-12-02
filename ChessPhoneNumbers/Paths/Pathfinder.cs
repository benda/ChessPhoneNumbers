using ChessPhoneNumbers.Trees;
using System.Collections.Generic;
using System.Linq;

namespace ChessPhoneNumbers.Domain
{
    class Pathfinder
    {
        private Keypad _keypad;
        //private HashSet<Path> _uniquePaths;
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

                    paths.AddRange(FindAllPathsForPosition(piece, maximumNumberOfKeysInPath));
                }
            }

            return paths;
        }

        private List<Path> FindAllPathsForPosition(Piece piece, int maximumNumberOfKeysInPath)
        {
            BuildPathsTree(piece, maximumNumberOfKeysInPath, _uniquePaths[piece.StartPosition.Item].Root, 1);

            return new List<Path>();
        }

        private void BuildPathsTree(Piece piece, int maximumNumberOfKeysInPath, TreeNode<Key> currentPosition, int currentDepth)
        {
            if(currentDepth == maximumNumberOfKeysInPath)
            {
                return;
            }

            var moves = piece.GetNextPotentialMoves();
            foreach(var move in moves)
            {
                piece.MoveTo(move.Destination);
                var destinationChildTreeNode = currentPosition.AddChild(move.Destination.Item);
                BuildPathsTree(piece, maximumNumberOfKeysInPath, destinationChildTreeNode, currentDepth + 1);
            }
/*
            if (!moves.Any())
            {
                return;
            }
            else
            {
                var move = moves.First();
                currentPath.Keys.Add(move.Destination.Item);
                piece.MoveTo(move.Destination);
                FindPath(piece, maximumNumberOfKeysInPath, currentPath);
            }*/

            /*
            foreach (var nextPosition in )
            {
                currentPath.Keys.Add(nextPosition.Destination.Item);
                FindPath(piece, maximumNumberOfKeysInPath, currentPath);
            }*/
        }
    }
}
