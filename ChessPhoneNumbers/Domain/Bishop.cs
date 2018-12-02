using ChessPhoneNumbers.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    class Bishop : Piece
    {
        public override IEnumerable<Edge<Key>> GetPossibleMoves()
        {
            var moves = new List<Edge<Key>>();
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
                    moves.Add(edgeToCheck);

                    foreach (var edge in edgeToCheck.Destination.Edges)
                    {
                        if (edge.Direction == edgeToCheck.Direction && edge.Origin == edgeToCheck.Destination)
                        {
                            edgesToCheck.Push(edge);
                        }
                    }
                }
            }

            return moves;
        }

        private bool IsAcceptableEdge(Edge<Key> edge)
        {
            return edge.Direction.IsDiagonal;
        }
    }
}
