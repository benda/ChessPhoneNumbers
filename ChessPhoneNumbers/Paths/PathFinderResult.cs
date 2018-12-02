using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Paths
{
    class PathFinderResult
    {
        public List<Path> AllPaths { get; }
        public IEnumerable<Tree<Key>> PathTrees { get; }

        public PathFinderResult(List<Path> allPaths, IEnumerable<Tree<Key>> pathTrees)
        {
            AllPaths = allPaths;
            PathTrees = pathTrees;
        }
    }
}
