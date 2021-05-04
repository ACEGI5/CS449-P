using System.Collections.Generic;
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

        [TestCase(0, 0, 3, 0, PieceState.Black)]
        public void TestValidMovement(int oldRow, int oldCol, int newRow, int newCol, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            var isValidMovement = sut.MovePiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.AreEqual(PieceState.Black, sut.GameBoard.GameBoard[newRow, newCol].PieceState);
            Assert.True(isValidMovement);
        }

        [TestCase(0, 0, 3, 0, PieceState.Black)]
        public void TestInvalidMovementNotAllPiecesPlaced(int oldRow, int oldCol, int newRow, int newCol,
            PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            var isValidMovement = sut.MovePiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.AreNotEqual(PieceState.Black, sut.GameBoard.GameBoard[newRow, newCol].PieceState);
            Assert.False(isValidMovement);
        }

        [TestCase(0, 0, 3, 0, PieceState.White)]
        public void TestInvalidMovementOccupied(int oldRow, int oldCol, int newRow, int newCol, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            sut.PlacePiece(sut.WhitePlayer, newRow, newCol);
            var isValidMovement = sut.MovePiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.AreEqual(color, sut.GameBoard.GameBoard[newRow, newCol].PieceState);
            Assert.False(isValidMovement);
        }

        [TestCase(0, 0, 1, 1, PieceState.Open)]
        [TestCase(0, 0, 6, 6, PieceState.Open)]
        public void TestInvalidMovementNotAdjacent(int oldRow, int oldCol, int newRow, int newCol, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            var isValidMovement = sut.MovePiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.AreEqual(color, sut.GameBoard.GameBoard[newRow, newCol].PieceState);
            Assert.False(isValidMovement);
        }

        [TestCase(0, 0, 3, 0)]
        [TestCase(0, 0, 0, 3)]
        public void TestIsValidValidSpot(int oldRow, int oldCol, int newRow, int newCol)
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            var isValidMovement = sut.MovePiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.True(isValidMovement);
        }

        [TestCase(0, 0, 6, 6)]
        [TestCase(0, 0, 1, 1)]
        [TestCase(0, 0, 3, 1)]
        public void TestIsValidInvalidSpot(int oldRow, int oldCol, int newRow, int newCol)
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            sut.PlacePiece(sut.BlackPlayer, 3, 1);
            var isValidMovement = sut.MovePiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.False(isValidMovement);
        }

        [TestCase(0, 0, 1, 1, PieceState.Black)]
        public void TestValidFly(int oldRow, int oldCol, int newRow, int newCol, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 1; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.BlackPlayer.RemovePiece();
            }

            
            var isValidFly = sut.FlyPiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.AreEqual(color, sut.GameBoard.GameBoard[newRow, newCol].PieceState);
            Assert.True(isValidFly);
        }

        [TestCase(0, 0, 1, 1, PieceState.White)]
        public void TestInvalidFlyOccupied(int oldRow, int oldCol, int newRow, int newCol, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 1; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.BlackPlayer.RemovePiece();
            }
            sut.PlacePiece(sut.WhitePlayer, newRow, newCol);
            var isValidFly = sut.FlyPiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.AreEqual(color, sut.GameBoard.GameBoard[newRow, newCol].PieceState);
            Assert.False(isValidFly);
        }
        [TestCase(0, 0, 3, 3, PieceState.Invalid)]
        public void TestInvalidFlyInvalidPosition(int oldRow, int oldCol, int newRow, int newCol, PieceState color)
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 1; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, oldRow, oldCol);
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.BlackPlayer.RemovePiece();
            }
            var isValidFly = sut.FlyPiece(sut.BlackPlayer, newRow, newCol, oldRow, oldCol);
            Assert.AreEqual(color, sut.GameBoard.GameBoard[newRow, newCol].PieceState);
            Assert.False(isValidFly);
        }

        [Test]
        public void TestValidMillPlacementVerticalNotCentered()
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.BlackPlayer, 1, 5);
            sut.PlacePiece(sut.BlackPlayer, 3, 5);
            sut.PlacePiece(sut.BlackPlayer, 5, 5);

            Assert.IsTrue(sut.CheckMill(3, 5, sut.BlackPlayer));

        }
        
        [Test]
        public void TestValidMillPlacementHorizontalNotCentered()
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.BlackPlayer, 3, 0);
            sut.PlacePiece(sut.BlackPlayer, 3, 1);
            sut.PlacePiece(sut.BlackPlayer, 3, 2);

            Assert.IsTrue(sut.CheckMill(3, 0, sut.BlackPlayer));
            Assert.IsTrue(sut.CheckMill(3, 1, sut.BlackPlayer));
        }
        
        [Test]
        public void TestInvalidMillPlacementVerticalCentered()
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.BlackPlayer, 2, 4);
            sut.PlacePiece(sut.BlackPlayer, 3, 4);
            sut.PlacePiece(sut.BlackPlayer, 5, 4);

            Assert.IsFalse(sut.CheckMill(3, 5, sut.BlackPlayer));

        }
        
        [Test]
        public void TestInvalidMillPlacementHorizontalCentered()
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.BlackPlayer, 3, 2);
            sut.PlacePiece(sut.BlackPlayer, 3, 4);
            sut.PlacePiece(sut.BlackPlayer, 3, 5);

            Assert.IsFalse(sut.CheckMill(3, 5, sut.BlackPlayer));

        }

        [Test]
        public void TestValidPieceRemoval()
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.WhitePlayer, 0, 0);
            sut.PlacePiece(sut.BlackPlayer, 3, 4);
            sut.PlacePiece(sut.BlackPlayer, 3, 5);
            sut.PlacePiece(sut.BlackPlayer, 3, 6);
            Assert.AreEqual(PieceState.White, sut.GameBoard.GameBoard[0, 0].PieceState);
            sut.RemovePiece(sut.BlackPlayer, 0, 0);
            Assert.AreEqual(PieceState.Open, sut.GameBoard.GameBoard[0, 0].PieceState);
        }

        [Test]
        public void TestValidPieceRemovalOnlyMillsLeft()
        {
            var sut = new NineMansMorrisLogic();
            
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 3; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }
            
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 0; i--)
            {
                sut.BlackPlayer.RemovePiece();
            }
            
            sut.PlacePiece(sut.BlackPlayer, 3, 4);
            sut.PlacePiece(sut.BlackPlayer, 3, 5);
            sut.PlacePiece(sut.BlackPlayer, 3, 6);
            Assert.IsTrue(sut.CheckMill(3, 5, sut.BlackPlayer));
            
            sut.PlacePiece(sut.WhitePlayer, 6, 0);
            sut.PlacePiece(sut.WhitePlayer, 6, 6);
            
            sut.PlacePiece(sut.WhitePlayer, 0, 0);
            sut.PlacePiece(sut.WhitePlayer, 3, 0);
            sut.PlacePiece(sut.WhitePlayer, 6, 0);
            Assert.IsTrue(sut.CheckMill(3, 0, sut.WhitePlayer));

            Assert.IsTrue(sut.RemovePiece(sut.WhitePlayer, 3, 5));
        }

        [Test]
        public void TestInvalidPieceRemoval()
        {
            var sut = new NineMansMorrisLogic();
            
            sut.PlacePiece(sut.BlackPlayer, 3, 4);
            sut.PlacePiece(sut.BlackPlayer, 3, 5);
            sut.PlacePiece(sut.BlackPlayer, 3, 6);
            Assert.IsTrue(sut.CheckMill(3, 5, sut.BlackPlayer));
            
            sut.PlacePiece(sut.WhitePlayer, 0, 0);
            sut.PlacePiece(sut.WhitePlayer, 3, 0);
            sut.PlacePiece(sut.WhitePlayer, 6, 0);
            Assert.IsTrue(sut.CheckMill(3, 0, sut.WhitePlayer));

            sut.PlacePiece(sut.WhitePlayer, 6, 0);
            sut.PlacePiece(sut.BlackPlayer, 3, 6);
            sut.PlacePiece(sut.WhitePlayer, 6, 6);
            
            Assert.IsFalse(sut.RemovePiece(sut.BlackPlayer, 3, 5));
        }
        
        [Test]
        public void TestOutOfBoundsMovement()
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.BlackPlayer, 6, 1);
            sut.PlacePiece(sut.BlackPlayer, 6, 3);
            sut.PlacePiece(sut.BlackPlayer, 6, 6);
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }


            var isValidMovement = sut.MovePiece(sut.BlackPlayer, 7, 1, 6, 1);
            Assert.False(isValidMovement);
        }

        [Test]
        public void TestOverCenterMovement()
        {
            var sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.BlackPlayer, 3, 0);
            sut.PlacePiece(sut.BlackPlayer, 3, 1);
            sut.PlacePiece(sut.BlackPlayer, 3, 2);
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }


            var isValidMovement = sut.MovePiece(sut.BlackPlayer, 3, 4, 3, 2);
            Assert.False(isValidMovement);
        }

        [Test]
        public void TestGameOver()
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 1; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, 0, 0);
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.BlackPlayer.RemovePiece();
            }

            sut.RemovePiece(sut.WhitePlayer, 0, 0);
            Assert.True(sut.GameOver);
        }
        
        [Test]
        public void TestGameOverPlacePiece()
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 1; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, 0, 0);
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.BlackPlayer.RemovePiece();
            }

            sut.RemovePiece(sut.WhitePlayer, 0, 0);
            Assert.True(sut.GameOver);
            sut.PlacePiece(sut.WhitePlayer, 6, 6);
            Assert.AreEqual( PieceState.Open,sut.GameBoard.GameBoard[6,6].PieceState);
        }
        
        [Test]
        public void TestGameOverMovePiece()
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 1; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, 0, 0);
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.BlackPlayer.RemovePiece();
            }

            sut.RemovePiece(sut.WhitePlayer, 0, 0);
            Assert.True(sut.GameOver);
            var isValidMovement = sut.MovePiece(sut.BlackPlayer, 0, 0, 3, 0);
            Assert.IsFalse(isValidMovement);
        }
        
        [Test]
        public void TestGameOverFlyPiece()
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 1; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            sut.PlacePiece(sut.BlackPlayer, 0, 0);
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.BlackPlayer.RemovePiece();
            }

            sut.RemovePiece(sut.WhitePlayer, 0, 0);
            Assert.True(sut.GameOver);
            var isValidFly = sut.FlyPiece(sut.BlackPlayer, 0, 0, 3, 0);
            Assert.IsFalse(isValidFly);
        }
        
        [Test]
        public void TestGameOverRemovePiece()
        {
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 1; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }
            
            sut.PlacePiece(sut.BlackPlayer, 0, 0);
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.BlackPlayer.RemovePiece();
            }

            sut.RemovePiece(sut.WhitePlayer, 0, 0);
            Assert.True(sut.GameOver);
            sut.PlacePiece(sut.BlackPlayer, 0, 3);
            var isValidRemoval = sut.RemovePiece(sut.BlackPlayer, 0, 3);
            Assert.IsFalse(isValidRemoval);
        }
        [Test]
        public void TestValidGetAdjacent()
        {
            var sut = new NineMansMorrisLogic();
            var possibleMoves = new List<List<int>>();
            
            var row = 3;
            var col = 1;
            var up = new List<int>() {1, 1};
            var down = new List<int>() {5,1};
            var left = new List<int>() {3,0};
            var right = new List<int>() {3,2};
            
            
            //1,1 3,0  3,2  5,1
            possibleMoves = sut.GetValidAdjacentCoordinates(row, col);
            
            Assert.True((possibleMoves.Contains(up) && possibleMoves.Contains(up) && possibleMoves.Contains(up) &&
                         possibleMoves.Contains(up)));
            


        }
    }

}