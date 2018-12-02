using ChessPhoneNumbers.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    class Knight : Piece
    {
        protected override bool IsAcceptableEdge(Edge<Key> edge)
        {
            return edge.Direction == Direction.North || edge.Direction == Direction.South || edge.Direction == Direction.East || edge.Direction == Direction.West;
        }

        protected override int? MaximumCostPerMove => 3;

        protected override bool IsAcceptableMove(Move m)
        {
            if(m.Cost != 3)
            {
                return false;              
            }

            int nCount = 0;
            int sCount = 0;
            int eCount = 0;
            int wCount = 0;

            foreach(var edge in m.Path)
            {
                if(edge.Direction == Direction.North)
                {
                    nCount++;
                }

                if (edge.Direction == Direction.South)
                {
                    sCount++;
                }

                if (edge.Direction == Direction.East)
                {
                    eCount++;
                }
                if (edge.Direction == Direction.West)
                {
                    wCount++;
                }
            }

            if ((nCount == 2 && eCount == 1) || (nCount == 2 && wCount == 1))
            {
                return true;
            }

            if ((sCount == 2 && eCount == 1) || (sCount == 2 && wCount == 1))
            {
                return true;
            }

            if ((eCount == 2 && nCount == 1) || (eCount == 2 && sCount == 1))
            {
                return true;
            }

            if ((wCount == 2 && nCount == 1) || (wCount == 2 && sCount == 1))
            {
                return true;
            }

            return false;
        }
    }
}
