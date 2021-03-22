using NineMansMorrisLib;
using NUnit.Framework;

namespace NineMansMorrisTests
{
    [TestFixture]
    public class NineMansMorrisLogicTest
    {
        [TestCase(0, 0, PieceState.White)]
        public void TestValidPlacePiece(int row, int col, PieceState color)
        {
            var sut = new NineMansMorrisLogic();

            sut.PlacePiece(sut.WhitePlayer, row, col);

            Assert.AreEqual(PieceState.White, sut.GameBoard.GameBoard[row, col].PieceState);
        }

        [TestCase(0, 1, PieceState.White)]
        public void TestInvalidPiecePlacementInvalidSpot(int row, int col, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.WhitePlayer, row, col);
            Assert.AreEqual(PieceState.Invalid, sut.GameBoard.GameBoard[row, col].PieceState);
        }

        [TestCase(0, 0, PieceState.White)]
        public void TestInvalidPiecePlacementOccupiedSpot(int row, int col, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.BlackPlayer, row, col);
            sut.PlacePiece(sut.WhitePlayer, row, col);
            Assert.AreEqual(PieceState.Black, sut.GameBoard.GameBoard[row, col].PieceState);
        }

        [TestCase(0, 0)]
        public void TestTurnSwitchingOnPlacement(int row, int col)
        {
            var sut = new NineMansMorrisLogic();
            if (sut.Turn == 0)
            {
                sut.PlacePiece(sut.WhitePlayer, row, col);
                Assert.AreEqual(sut.Turn, 1);
            }
            else if (sut.Turn == 1)
            {
                sut.PlacePiece(sut.BlackPlayer, row, col);
                Assert.AreEqual(sut.Turn, 0);
            }
        }

        [TestCase(0, 1)]
        public void TestNotTurnSwitchingOnInvalidSpot(int row, int col)
        {
            var sut = new NineMansMorrisLogic();
            if (sut.Turn == 0)
            {
                sut.PlacePiece(sut.WhitePlayer, row, col);
                Assert.AreEqual(sut.Turn, 0);
            }
            else if (sut.Turn == 1)
            {
                sut.PlacePiece(sut.BlackPlayer, row, col);
                Assert.AreEqual(sut.Turn, 1);
            }
        }

        [TestCase(0, 0)]
        public void TestNotTurnSwitchingOnOccupiedSpot(int row, int col)
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.WhitePlayer, row, col);
            if (sut.Turn == 0)
            {
                sut.PlacePiece(sut.WhitePlayer, row, col);
                Assert.AreEqual(sut.Turn, 0);
            }
            else if (sut.Turn == 1)
            {
                sut.PlacePiece(sut.BlackPlayer, row, col);
                Assert.AreEqual(sut.Turn, 1);
            }
        }

        [TestCase(0, 1)]
        public void TestRandomPlayerSelected(int row, int col)
        {
            var sut = new NineMansMorrisLogic();
            switch (sut.Turn)
            {
                case 0:
                    Assert.AreEqual(sut.Turn, 0);
                    break;
                case 1:
                    Assert.AreEqual(sut.Turn, 1);
                    break;
            }
        }
    }
}