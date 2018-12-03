using System;
using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.PhoneNumbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class PhoneNumberServiceTests
    {
        [TestMethod]
        public void FindAllPhoneNumbers()
        {
            PhoneNumberService pns = new PhoneNumberService();
            Assert.AreEqual(0, pns.FindAllPhoneNumbers(Pieces.Pawn.Piece).AllPaths.Count); //pawns can't reverse direction 
            Assert.AreEqual(2341, pns.FindAllPhoneNumbers(Pieces.Bishop.Piece).AllPaths.Count);
            Assert.AreEqual(952, pns.FindAllPhoneNumbers(Pieces.Knight.Piece).AllPaths.Count);
            Assert.AreEqual(49326, pns.FindAllPhoneNumbers(Pieces.Rook.Piece).AllPaths.Count);
            Assert.AreEqual(124908, pns.FindAllPhoneNumbers(Pieces.King.Piece).AllPaths.Count);
            Assert.AreEqual(751503, pns.FindAllPhoneNumbers(Pieces.Queen.Piece).AllPaths.Count);
        }
    }
}
