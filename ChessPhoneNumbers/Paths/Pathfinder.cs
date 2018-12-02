using System.Collections.Generic;
using System.Linq;

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
                piece.MoveTo(startPosition);
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
            if(currentPath.Keys.Count == 0)
            {
                currentPath.Keys.Add(piece.Position.Item);
            }

            if (currentPath.Keys.Count == maximumNumberOfKeysInPath)
            {
                return;
            }

            var moves = piece.GetNextPotentialMoves();
            if(!moves.Any())
            {
                return;
            }
            else
            {
                var move = moves.First();
                currentPath.Keys.Add(move.Destination.Item);
                piece.MoveTo(move.Destination);
                FindPath(piece, maximumNumberOfKeysInPath, currentPath);
            }

            /*
            foreach (var nextPosition in )
            {
                currentPath.Keys.Add(nextPosition.Destination.Item);
                FindPath(piece, maximumNumberOfKeysInPath, currentPath);
            }*/
        }
    }
}
