using System;

namespace NineMansMorrisLib {
    
    public class Board {
        
        public const int BoardSize = 7;
        // thought: if we're following documentation and given this is a private variable-- 
        // should this then be _CenterOfBoard?
        private const int CenterOfBoard = BoardSize / 2;
        public GamePiece[,] GameBoard { get; private set; }

        public Board() {
            
            GameBoard = new GamePiece[BoardSize, BoardSize];
            PopulateBoard(GameBoard);
            
        }

        //populates board with open and invalid positions
        // what was your reasoning to make the following methods static?
        // *because under my understanding right now*: we're creating one
        // board at a time; one instance. so what are the impacts of having a static method?
        private static void PopulateBoard(GamePiece[,] boardArray) {
            
            PopulateDiagonal(boardArray);
            PopulateMiddleCells(boardArray);
            PopulateReverseDiagonal(boardArray);
            
        }

        // all of these methods need commenting
        private static void PopulateMiddleCells(GamePiece[,] boardArray) {
            
            for (var row = 0; row < BoardSize; row++) {
                
                for (var col = 0; col < BoardSize; col++) {
                    
                    if (row == CenterOfBoard || col == CenterOfBoard) {
                        
                        boardArray[row, col] = new GamePiece() {PieceState = PieceState.Open};
                        
                    }

                    // why are we using a null-coalescing operator ?
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
        
        // isAdjacent was here

    }
    
}