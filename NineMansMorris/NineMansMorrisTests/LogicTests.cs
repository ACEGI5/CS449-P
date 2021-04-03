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

            Assert.AreEqual(color, sut.GameBoard.GameBoard[row, col].PieceState);
        }

        [TestCase(0, 1, PieceState.Invalid)]
        public void TestInvalidPiecePlacementInvalidSpot(int row, int col, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.WhitePlayer, row, col);
            Assert.AreEqual(color, sut.GameBoard.GameBoard[row, col].PieceState);
        }

        [TestCase(0, 0, PieceState.Black)]
        public void TestInvalidPiecePlacementOccupiedSpot(int row, int col, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.BlackPlayer, row, col);
            sut.PlacePiece(sut.WhitePlayer, row, col);
            Assert.AreEqual(color, sut.GameBoard.GameBoard[row, col].PieceState);
        }
        [TestCase(0, 0,3,0, PieceState.Black)]
        public void TestValidMovement(int oldRow, int oldCol,int newRow, int newCol, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            for (int i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            bool isValidMovement = sut.MovePiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.AreEqual(PieceState.Black,sut.GameBoard.GameBoard[newRow,newCol].PieceState);
            Assert.True(isValidMovement);
        }
        [TestCase(0, 0,3,0, PieceState.Black)]
        public void TestInvalidMovementNotAllPiecesPlaced(int oldRow, int oldCol,int newRow, int newCol, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            bool isValidMovement = sut.MovePiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.AreNotEqual(PieceState.Black,sut.GameBoard.GameBoard[newRow,newCol].PieceState);
            Assert.False(isValidMovement);
        }
        [TestCase(0, 0,3,0, PieceState.White)]
        public void TestInvalidMovementOccupied(int oldRow, int oldCol,int newRow, int newCol, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            for (int i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            sut.PlacePiece(sut.WhitePlayer, newRow, newCol);
            bool isValidMovement = sut.MovePiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.AreEqual(color,sut.GameBoard.GameBoard[newRow,newCol].PieceState);
            Assert.False(isValidMovement);
        }
        [TestCase(0, 0,1,1, PieceState.Open)]
        [TestCase(0, 0,6,6, PieceState.Open)]
        public void TestInvalidMovementNotAdjacent(int oldRow, int oldCol,int newRow, int newCol, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            for (int i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            bool isValidMovement = sut.MovePiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.AreEqual(color,sut.GameBoard.GameBoard[newRow,newCol].PieceState);
            Assert.False(isValidMovement);
        }
        [TestCase(0, 0,3,1)]
        [TestCase(0, 0,0,3 )]
        public void TestIsValidValidSpot(int oldRow, int oldCol,int newRow, int newCol)
        {
            var sut = new NineMansMorrisLogic();
            for (int i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            bool isValidMovement = sut.MovePiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.True(isValidMovement);
        }
        [TestCase(0, 0,6,6)]
        [TestCase(0, 0,1,1 )]
        [TestCase(0, 0,3,1 )]
        public void TestIsValidInValidSpot(int oldRow, int oldCol,int newRow, int newCol)
        {
            var sut = new NineMansMorrisLogic();
            for (int i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            sut.PlacePiece(sut.BlackPlayer, 3, 1);
            bool isValidMovement = sut.MovePiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.False(isValidMovement);
        }
        [TestCase(0, 0,1,1, PieceState.Black)]
        public void TestValidFly(int oldRow, int oldCol, int newRow, int newCol, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            for (int i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }
            for (int i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.BlackPlayer.RemovePiece();
            }
            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            bool isValidFly = sut.FlyPiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.AreEqual(color,sut.GameBoard.GameBoard[newRow,newCol].PieceState);
            Assert.True(isValidFly);
        }
    }
}