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
        public override IEnumerable<Edge<Key>> GetNextPotentialMoves()
        {
            var moves = new List<Edge<Key>>();
            Stack<Edge<Key>> edgesToCheck = new Stack<Edge<Key>>();

            foreach (var edge in Position.Edges)
            {
                edgesToCheck.Push(edge);
            }
            Direction currentDirection = null;

            while (edgesToCheck.Count > 0)
            {
                var edgeToCheck = edgesToCheck.Pop();

                if(IsAcceptableEdge(edgeToCheck))
                {
                    if(currentDirection == null)
                    {
                        currentDirection = edgeToCheck.Direction;
                    }
                    moves.Add(edgeToCheck);
                    
                    foreach(var edge in edgeToCheck.Destination.Edges)
                    {
                        if (edge.Direction == currentDirection && edge.Origin == edgeToCheck.Destination)
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

            /*
                    private Vertex<Key> GetNext(Edge<Key> edge)
                    {
                        if (edge.Direction.IsDiagonal)
                        {
                            if (edge.VertexA == Position)
                            {
                                return edge.VertexB;
                            }
                            else
                            {
                                return edge.VertexA;
                            }
                        }
                    }
                    */
        }
}
