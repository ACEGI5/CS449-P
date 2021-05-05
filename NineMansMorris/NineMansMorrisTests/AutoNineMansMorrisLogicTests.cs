using NineMansMorrisLib;
using NUnit.Framework;

namespace NineMansMorrisTests
{
    public class AutoNineMansMorrisLogicTests
    {
        [Test]
        public void TestValidAutoPlacement()
        {
            var sut = new AutoNineMansMorrisLogic();

            for (var i = sut.BlackPlayer.PiecesToPlace; i > 1; i--)
            {
                sut.PlacePiece(sut.BlackPlayer);
            }

            var numBefore = LogicHelper.GetPieces(PieceState.Black, sut.GameBoard).Count;
            sut.PlacePiece(sut.BlackPlayer);
            var numAfter = LogicHelper.GetPieces(PieceState.Black, sut.GameBoard).Count - 1;
            Assert.AreEqual(numBefore, numAfter);
        }

        [Test]
        public void TestValidAutoMovement()
        {
            var sut = new AutoNineMansMorrisLogic();

            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.PlacePiece(sut.BlackPlayer);
            }

            var numBefore = LogicHelper.GetPieces(PieceState.Black, sut.GameBoard).Count;
            sut.MovePiece(sut.BlackPlayer);
            var numAfter = LogicHelper.GetPieces(PieceState.Black, sut.GameBoard).Count;
            Assert.AreEqual(numBefore, numAfter);
        }
        
        [Test]
        public void TestValidAutoRemoval()
        {
            var sut = new AutoNineMansMorrisLogic();

            
            var row = 0;
            var col = 0;
            
            sut.PlacePiece(sut.WhitePlayer, row, col);


            sut.RemovePiece(sut.BlackPlayer);
            Assert.AreEqual(sut.GameBoard.GameBoard[row, col].PieceState, PieceState.Open);

        }
        
        [Test]
        public void TestValidAutoFlyPiece()
        {
            var sut = new AutoNineMansMorrisLogic();

            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.PlacePiece(sut.BlackPlayer);
            }
            
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.RemovePiece(sut.WhitePlayer);
            }

            var numBefore = LogicHelper.GetPieces(PieceState.Black, sut.GameBoard).Count;
            var didFly = sut.FlyPiece(sut.BlackPlayer);
            var numAfter = LogicHelper.GetPieces(PieceState.Black, sut.GameBoard).Count;
            Assert.AreEqual(numBefore, numAfter);
            Assert.True(didFly);
        }
        
        [Test]
        public void TestInvalidAutoFlyPiece()
        {
            var sut = new AutoNineMansMorrisLogic();

            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.PlacePiece(sut.BlackPlayer);
            }

            var numBefore = LogicHelper.GetPieces(PieceState.Black, sut.GameBoard).Count;
            var didFly = sut.FlyPiece(sut.BlackPlayer);
            var numAfter = LogicHelper.GetPieces(PieceState.Black, sut.GameBoard).Count;
            Assert.AreEqual(numBefore, numAfter);
            Assert.False(didFly);
        }
        
        [Test]
        public void TestAutoGameOver()
        {
            var sut = new AutoNineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.PlacePiece(sut.BlackPlayer);
            }
            
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.RemovePiece(sut.WhitePlayer);
            }

            sut.RemovePiece(sut.WhitePlayer);
            Assert.True(sut.GameOver);
        }
        
        [Test]
        public void TestAutoGameOverPlacePiece()
        {
            var sut = new AutoNineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.PlacePiece(sut.BlackPlayer);
            }
            
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.RemovePiece(sut.WhitePlayer);
            }

            sut.RemovePiece(sut.WhitePlayer);
            Assert.True(sut.GameOver);
            sut.PlacePiece(sut.BlackPlayer);
            var numBefore = LogicHelper.GetPieces(PieceState.Black, sut.GameBoard).Count;
            sut.PlacePiece(sut.BlackPlayer);
            var numAfter = LogicHelper.GetPieces(PieceState.Black, sut.GameBoard).Count;
            Assert.AreEqual(numBefore, numAfter);
        }
        
        [Test]
        public void TestAutoGameOverMovePiece()
        {
            var sut = new AutoNineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.PlacePiece(sut.BlackPlayer);
            }
            
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.RemovePiece(sut.WhitePlayer);
            }

            sut.RemovePiece(sut.WhitePlayer);
            Assert.True(sut.GameOver);
            var isValidMovement = sut.MovePiece(sut.BlackPlayer);
            Assert.IsFalse(isValidMovement);
        }

        
        [Test]
        public void TestAutoGameOverFlyPiece()
        {
            var sut = new AutoNineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.PlacePiece(sut.BlackPlayer);
            }
            
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.RemovePiece(sut.WhitePlayer);
            }

            sut.RemovePiece(sut.WhitePlayer);
            Assert.True(sut.GameOver);
            var isValidFly = sut.FlyPiece(sut.BlackPlayer);
            Assert.IsFalse(isValidFly);
        }
        
        [Test]
        public void TestAutoGameOverRemovePiece()
        {
            var sut = new AutoNineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 1; i--)
            {
                sut.PlacePiece(sut.BlackPlayer);
            }

            sut.PlacePiece(sut.BlackPlayer);
            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.RemovePiece(sut.WhitePlayer);
            }

            sut.RemovePiece(sut.WhitePlayer);
            Assert.True(sut.GameOver);
        }
    }
}
    
    
