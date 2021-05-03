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
    }
}
    
    
