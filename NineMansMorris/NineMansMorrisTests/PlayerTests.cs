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
        }

        public void TestPlayerCanFly()
        {
            //Test that when player has placed all pieces and has only three pieces left, CanFly is active.
        }

        public void TestPlayerHasLost()
        {
            // Test that when player has less than three pieces, then PlayerHasLost should return true.
        }
    }
}