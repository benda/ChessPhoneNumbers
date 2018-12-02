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

        public IEnumerable<Move> GetPossibleMoves()
        {
            var moves = new List<Move>();

            Stack<Move> edgesToCheck = new Stack<Move>();

            foreach (var edge in Position.Edges)
            {
                var move = new Move(edge.Destination, 1, Position);
                move.Path.Add(edge);
                edgesToCheck.Push(move);
            }

            while (edgesToCheck.Count > 0)
            {
                var move = edgesToCheck.Pop();

                Edge<Key> edgeToCheck = move.Path[move.Path.Count - 1];

                if (IsAcceptableEdge(edgeToCheck))
                {                 
                    moves.Add(move);

                    if (!MaximumCostPerMove.HasValue || move.Cost < MaximumCostPerMove)
                    {
                        foreach (var edge in edgeToCheck.Destination.Edges)
                        {
                            if (edge.Direction == edgeToCheck.Direction && edge.Origin == edgeToCheck.Destination)
                            {
                                var multipleCostMove = new Move(edgeToCheck.Destination, move.Cost, Position);
                                multipleCostMove.Path.AddRange(move.Path);
                                multipleCostMove.Path.Add(edgeToCheck);
                                multipleCostMove.Cost += edgeToCheck.Cost;

                                edgesToCheck.Push(multipleCostMove);
                            }
                        }
                    }
                }
            }

            return (from m in moves where IsAcceptableMove(m) select m);
        }

        protected virtual bool IsAcceptableMove(Move m)
        {
            return true;
        }

        protected abstract bool IsAcceptableEdge(Edge<Key> edge);
        protected abstract int? MaximumCostPerMove { get; }

        public void MoveTo(Vertex<Key> newPosition)
        {
            Position = newPosition;
        }
    }
}
