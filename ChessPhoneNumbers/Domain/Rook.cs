﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessPhoneNumbers.Graphs;

namespace ChessPhoneNumbers.Domain
{
    class Rook : Piece
    {
        public override IEnumerable<Vertex<Key>> GetNextPotentialMoves()
        {
            throw new NotImplementedException();
        }
    }
}
