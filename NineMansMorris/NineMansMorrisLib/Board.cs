using System;

namespace NineMansMorrisLib {
    
    public class Board {
        
        public const int BoardSize = 7;
        private const int CenterOfBoard = BoardSize / 2;
        public GamePiece[,] GameBoard { get; private set; }

        public Board() {
            
            GameBoard = new GamePiece[BoardSize, BoardSize];
            PopulateBoard(GameBoard);
            
        }

        //populates board with open and invalid positions
        private static void PopulateBoard(GamePiece[,] boardArray) {
            
            PopulateDiagonal(boardArray);
            PopulateMiddleCells(boardArray);
            PopulateReverseDiagonal(boardArray);
            
        }

        private static void PopulateMiddleCells(GamePiece[,] boardArray) {
            
            for (var row = 0; row < BoardSize; row++) {
                
                for (var col = 0; col < BoardSize; col++) {
                    
                    if (row == CenterOfBoard || col == CenterOfBoard) {
                        
                        boardArray[row, col] = new GamePiece() {PieceState = PieceState.Open};
                        
                    }

                    boardArray[row, col] ??= new GamePiece() {PieceState = PieceState.Invalid};
                    
                }
                
            }

            boardArray[CenterOfBoard, CenterOfBoard].PieceState = PieceState.Invalid;
            
        }

        private static void PopulateReverseDiagonal(GamePiece[,] boardArray) {
            
            for (int row = BoardSize - 1, col = 0; row >= 0 && col < BoardSize; row--, col++) {
                
                boardArray[row, col] = new GamePiece {PieceState = PieceState.Open};
                
            }
            
        }

        private static void PopulateDiagonal(GamePiece[,] boardArray) {
            
            for (var row = 0; row < BoardSize; row++) {
                
                boardArray[row, row] = new GamePiece {PieceState = PieceState.Open};
                
            }
            
        }

        //public bool CheckIfAdjacent(int newRow, int newCol, int oldRow, int oldCol) {
            
           // return (Math.Abs(newRow - oldRow) + Math.Abs(newCol - oldCol)) == 1;
            
        //}
        
    }
    
}