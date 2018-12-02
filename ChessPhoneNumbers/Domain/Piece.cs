using ChessPhoneNumbers.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    abstract class Piece
    {
        public Vertex<Key> Position { get; private set; }

        public virtual IEnumerable<Vertex<Key>> GetPossibleMoves()
        {
            var moves = new List<Vertex<Key>>();

            Stack<Edge<Key>> edgesToCheck = new Stack<Edge<Key>>();

            foreach (var edge in Position.Edges)
            {
                edgesToCheck.Push(edge);
            }

            while (edgesToCheck.Count > 0)
            {
                var edgeToCheck = edgesToCheck.Pop();

                if (IsAcceptableEdge(edgeToCheck))
                {
                    moves.Add(edgeToCheck.Destination);

                    if (!MaximumCostPerMove.HasValue || edgeToCheck.Cost < MaximumCostPerMove)
                    {
                        foreach (var edge in edgeToCheck.Destination.Edges)
                        {
                            if (edge.Direction == edgeToCheck.Direction && edge.Origin == edgeToCheck.Destination)
                            {
                                edgesToCheck.Push(edge);
                            }
                        }
                    }
                }
            }

            return moves;
        }

        protected abstract bool IsAcceptableEdge(Edge<Key> edge);
        protected abstract int? MaximumCostPerMove { get; }

        public void MoveTo(Vertex<Key> newPosition)
        {
            Position = newPosition;
        }
    }
}
