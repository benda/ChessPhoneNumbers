using System.Collections.Generic;

namespace ChessPhoneNumbers.Domain
{
    class Pathfinder
    {
        private Keypad _keypad;

        public Pathfinder(Keypad keypad)
        {
            _keypad = keypad;
        }

        public List<Path> FindAllPaths(Piece piece, int maximumNumberOfKeysInPath)
        {
            List<Path> paths = new List<Path>();

            foreach (var startPosition in _keypad.Graph.Vertices)
            {
                piece.Position = startPosition;
                paths.AddRange(FindAllPathsForPosition(piece, maximumNumberOfKeysInPath));
            }

            return paths;
        }

        private List<Path> FindAllPathsForPosition(Piece piece, int maximumNumberOfKeysInPath)
        {
            FindPath(piece, maximumNumberOfKeysInPath, new Path());
            return new List<Path>();
        }

        private void FindPath(Piece piece, int maximumNumberOfKeysInPath, Path currentPath)
        {
            if (currentPath.Keys.Count == maximumNumberOfKeysInPath)
            {
                return;
            }

            foreach (var nextPosition in piece.GetNextPotentialMoves())
            {
                currentPath.Keys.Add(nextPosition.Destination.Item);
                FindPath(piece, maximumNumberOfKeysInPath, currentPath);
            }
        }
    }
}
