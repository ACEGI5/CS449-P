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

            Assert.AreEqual(1, sut.BlackPlayer.PiecesToPlace);
            sut.PlacePiece(sut.BlackPlayer);
            Assert.AreEqual(0, sut.BlackPlayer.PiecesToPlace);
        }
        
        [Test]
        public void TestValidAutoMovement()
        {
            var sut = new AutoNineMansMorrisLogic();

            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            Assert.AreEqual(9, sut.BlackPlayer.PiecesInPlay);
            var isMoved = sut.MovePiece(sut.BlackPlayer);
            Assert.AreEqual(9, sut.BlackPlayer.PiecesInPlay);
            Assert.IsTrue(isMoved);
        }
    }
    
    
}