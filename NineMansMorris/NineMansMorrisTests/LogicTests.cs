using NineMansMorrisLib;
using NUnit.Framework;

namespace NineMansMorrisTests
{
    [TestFixture]
    public class NineMansMorrisLogic
    {
        [TestFixture]
        public class GamePieceTest
        {
            [Test]
            public void METHOD()
            {
                var gp = new GamePiece();
                Assert.NotNull(gp);
            }
        }
    }
}