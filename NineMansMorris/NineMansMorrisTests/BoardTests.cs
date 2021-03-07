using NineMansMorrisLib;
using NUnit.Framework;

namespace NineMansMorrisUiTests
{
    [TestFixture]
    public class BoardTests
    {
        // [TestCase(0, 0, PieceState.Open)]
        // [TestCase(6, 6, PieceState.Open)]
        // [TestCase(6, 0, PieceState.Open)]
        // [TestCase(0, 6, PieceState.Open)]
        // [TestCase(0, 3, PieceState.Open)]
        // [TestCase(6, 3, PieceState.Open)]
        // [TestCase(3, 6, PieceState.Open)]
        // [TestCase(3, 0, PieceState.Open)]
        
        public void TestValidPopulation(int row, int col, PieceState state)
        {
            var sut = new Board();
            Assert.AreEqual(sut.GameBoard[row, col].PieceState, state);
        }
        [TestCase(3, 3, PieceState.Invalid)]
        [TestCase(0, 2, PieceState.Invalid)]
        public void TestInvalidPopulation(int row, int col, PieceState state)
        {
            var sut = new Board();
            Assert.AreEqual(sut.GameBoard[row, col].PieceState, state);
        }
    }
}