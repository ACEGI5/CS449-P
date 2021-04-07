using NineMansMorrisLib;
using NUnit.Framework;

namespace NineMansMorrisTests
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void TestPlayerStartPieces()
        {
            // Test player starts with nine pieces to place on open spots of the board.
            var sut = new Player();
            Assert.IsTrue(sut.PiecesToPlace == 9);
        }
        
        [Test]
        public void TestPlayerCantFlyWhenPiecesGreaterThanThree()
        {
            //Test that when player has more than three pieces, they can't fly.
            var sut = new Player();
            Assert.IsFalse(sut.CanFly());
        }
        
        [Test]
        public void TestPlayerCanFlyWhenPiecesEqualThree()
        {
            //Test that when player has more than three pieces, they can't fly.
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            for (var i = sut.BlackPlayer.PiecesInPlay; i > 3; i--)
            {
                sut.BlackPlayer.RemovePiece();
            }

            Assert.IsTrue(sut.BlackPlayer.CanFly());
        }

        [Test]
        public void TestPlayerHasLost()
        {
            // Test that when player has less than three pieces, then PlayerHasLost should return true.
            var sut = new NineMansMorrisLogic();
            for (var i = sut.BlackPlayer.PiecesToPlace; i > 0; i--)
            {
                sut.BlackPlayer.PlacePiece();
            }

            for (var i = sut.BlackPlayer.PiecesInPlay; i > 2; i--)
            {
                sut.BlackPlayer.RemovePiece();
            }
            
            Assert.IsTrue(sut.BlackPlayer.PlayerHasLost());
        }
    }
}