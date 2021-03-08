﻿using NineMansMorrisLib;
using NUnit.Framework;

namespace NineMansMorrisTests
{
    [TestFixture]
    public class NineMansMorrisLogicTest
    {
        [TestCase(0, 0, PieceState.White)]
        public void TestValidPlacePiece(int row, int col, PieceState color)
        {
            NineMansMorrisLogic sut = new NineMansMorrisLogic();
            
            sut.PlacePiece(sut.WhitePlayer,row,col);
            
            Assert.AreEqual(PieceState.White,sut.GameBoard.GameBoard[row,col].PieceState);

        }
        [TestCase(0, 1, PieceState.White)]
        public void TestInvalidPiecePlacement(int row, int col, PieceState color)
        {
            NineMansMorrisLogic sut = new NineMansMorrisLogic();
            sut.PlacePiece(sut.WhitePlayer,row,col);
            Assert.AreEqual(PieceState.Invalid, sut.GameBoard.GameBoard[row, col].PieceState);
        }
       
    }
}