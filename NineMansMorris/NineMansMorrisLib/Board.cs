using System.Data;
using Microsoft.VisualBasic;

namespace NineMansMorrisLib
{
    public class Board
    {
        private const int BoardSize = 7;
        private const int CenterOfBoard = BoardSize / 2;
        public GamePiece[,] GameBoard { get; private set; }

        public Board()
        {
            GameBoard = new GamePiece[BoardSize, BoardSize];
            PopulateBoard(GameBoard);
        }

        private void PopulateBoard(GamePiece[,] boardArray)
        {
            for (var row = 0; row < BoardSize; row++)
            {
                boardArray[row, row] = new GamePiece {PieceState = PieceState.Open};
            }

            int r = BoardSize-1;
            int c = 0;
            for (; r >= 0 && c< BoardSize; r--, c++)
            {
                boardArray[r, c] = new GamePiece {PieceState = PieceState.Open};
            }

            for (var row = 0; row < BoardSize; row++)
            {
                for (var col = 0; col < BoardSize; col++)
                {
                    if (row == CenterOfBoard || col == CenterOfBoard)
                    {
                        boardArray[row, col] = new GamePiece() {PieceState = PieceState.Open};
                    }

                    boardArray[row, col] ??= new GamePiece() {PieceState = PieceState.Invalid};
                }
                
            }

            boardArray[CenterOfBoard, CenterOfBoard].PieceState = PieceState.Invalid;
        }
        

    }
}