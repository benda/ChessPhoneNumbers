using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.Graphs;
using ChessPhoneNumbers.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.PhoneNumbers
{
    class PhoneNumberService
    {
        private static Keypad _keypad = new KeypadGraphReader().Read("ChessPhoneNumbers.Data.keypad.txt");

        public PathFinderResult FindAllPhoneNumbers(Piece piece)
        {
            PathFinder pf = new PathFinder(_keypad);

            return pf.FindAllPaths(piece, new PhoneNumberValidator());
        }
    }
}
