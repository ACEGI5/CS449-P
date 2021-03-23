using System;
using System.Diagnostics;
using NineMansMorrisLib;
using NUnit.Framework;

namespace NineMansMorrisTests
{
    [TestFixture]
    public class BoardTests
    {
        private Stopwatch _stopWatch;

        [SetUp]
        public void Init()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }

        [TearDown]
        public void Cleanup()
        {
            _stopWatch.Stop();
            Console.WriteLine($"{_stopWatch.ElapsedMilliseconds} ms");
        }

        [TestCase(0, 0, PieceState.Open)]
        [TestCase(6, 6, PieceState.Open)]
        [TestCase(6, 0, PieceState.Open)]
        [TestCase(0, 6, PieceState.Open)]
        [TestCase(0, 3, PieceState.Open)]
        [TestCase(6, 3, PieceState.Open)]
        [TestCase(3, 6, PieceState.Open)]
        [TestCase(3, 0, PieceState.Open)]
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

        [TestCase(0, 0, PieceState.Open)]
        [TestCase(1, 1, PieceState.Open)]
        [TestCase(2, 2, PieceState.Open)]
        [TestCase(3, 3, PieceState.Invalid)]
        [TestCase(4, 4, PieceState.Open)]
        [TestCase(5, 5, PieceState.Open)]
        [TestCase(6, 6, PieceState.Open)]
        public void TestPopulateDiagonal(int row, int col, PieceState state)
        {
            //testing side effect of method
            var sut = new Board();
            Assert.AreEqual(sut.GameBoard[row, col].PieceState, state);
        }

        [TestCase(0, 6, PieceState.Open)]
        [TestCase(1, 5, PieceState.Open)]
        [TestCase(2, 4, PieceState.Open)]
        [TestCase(3, 3, PieceState.Invalid)]
        [TestCase(4, 2, PieceState.Open)]
        [TestCase(5, 1, PieceState.Open)]
        [TestCase(6, 0, PieceState.Open)]
        public void TestPopulateReverseDiagonal(int row, int col, PieceState state)
        {
            //testing side effect of method
            var sut = new Board();
            Assert.AreEqual(sut.GameBoard[row, col].PieceState, state);
        }

        [TestCase(0, 3, PieceState.Open)]
        [TestCase(1, 3, PieceState.Open)]
        [TestCase(2, 3, PieceState.Open)]
        [TestCase(3, 3, PieceState.Invalid)]
        [TestCase(4, 3, PieceState.Open)]
        [TestCase(5, 3, PieceState.Open)]
        [TestCase(6, 3, PieceState.Open)]
        [TestCase(3, 0, PieceState.Open)]
        [TestCase(3, 1, PieceState.Open)]
        [TestCase(3, 4, PieceState.Open)]
        [TestCase(3, 5, PieceState.Open)]
        [TestCase(3, 6, PieceState.Open)]
        public void TestPopulateMiddleCells(int row, int col, PieceState state)
        {
            var sut = new Board();
            Assert.AreEqual(sut.GameBoard[row, col].PieceState, state);
        }
    }
}
