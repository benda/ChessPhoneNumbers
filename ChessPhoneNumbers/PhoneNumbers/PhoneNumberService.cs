﻿using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.PhoneNumbers
{
    class PhoneNumberService
    {
        private const int MaximumNumberOfDigitsInPhoneNumber = 7;

        public int FindAllPhoneNumbers(Piece piece)
        {
            Pathfinder pf = new Pathfinder(new Keypad(new GraphReader().Read("graph.txt")));

            return (from p in pf.FindAllPaths(piece, MaximumNumberOfDigitsInPhoneNumber) where IsValidPhoneNumber(p) select p).Count();
        }

        public bool IsValidPhoneNumber(Path path)
        {
            return path.Keys.Count == MaximumNumberOfDigitsInPhoneNumber && !path.Keys[0].IsValue(0) && !path.Keys[0].IsValue(1) && !path.Keys.Any(k => k.IsCharacter);
        }
    }
}
