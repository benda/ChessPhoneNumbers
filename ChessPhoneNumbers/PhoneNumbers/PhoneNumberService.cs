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
        public PathFinderResult FindAllPhoneNumbers(Piece piece)
        {
            Pathfinder pf = new Pathfinder(new KeypadGraphReader().Read("ChessPhoneNumbers.Data.keypad.txt"));

            return pf.FindAllPaths(piece, new PhoneNumberValidator());
        }
    }
}
