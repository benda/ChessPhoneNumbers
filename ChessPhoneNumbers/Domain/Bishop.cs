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
        public override IEnumerable<Vertex<Key>> GetNextPotentialMoves()
        {
            var moves = new List<Vertex<Key>>();

            foreach (var edge in Position.Edges)
            {
                if (edge.EdgeType == EdgeType.Diagonal)
                {
                    if (edge.VertexA == Position)
                    {
                        moves.Add(edge.VertexB);
                    }
                    else
                    {
                        moves.Add(edge.VertexA);
                    }
                }              
            }

            return moves;
        }
    }
}
