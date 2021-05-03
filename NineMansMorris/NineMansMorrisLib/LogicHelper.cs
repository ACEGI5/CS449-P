using System.Collections.Generic;

namespace NineMansMorrisLib
{
    public class LogicHelper
    {
        public static Board GameBoard { get; private set; }
        public Player WhitePlayer { get; private set; }
        public Player BlackPlayer { get; private set; }

        public LogicHelper(Board gameBoard, Player whitePlayer, Player blackPlayer)
        {
            GameBoard = gameBoard;
            WhitePlayer = whitePlayer;
            BlackPlayer = blackPlayer;
        }

        public static Dictionary<string, int[]> Directions { set; get; } = new Dictionary<string, int[]>
        {
            {"up", new[] {-1, 0}}, {"down", new[] {1, 0}},
            {"left", new[] {0, -1}}, {"right", new[] {0, 1}}
        };

        public static bool IsValid(int rowTo, int colTo, int rowFrom, int colFrom)
        {
            // traverse each direction
            foreach (var direction in LogicHelper.Directions)
            {
                // while move is not possible
                var row = rowFrom;
                var col = colFrom;
                while (true)
                {
                    // update position
                    row += direction.Value[0];
                    col += direction.Value[1];

                    // if out of bounds
                    if ((row > 6 || col > 6) || (col <= -1) || (row <= -1))
                    {
                        break;
                    }

                    // if middle, do not cross
                    if (row == 3 && col == 3)
                    {
                        break;
                    }

                    // if black, white, open
                    if (GameBoard.GameBoard[row, col].PieceState != PieceState.Invalid)
                    {
                        // if spot is open
                        if (GameBoard.GameBoard[row, col].PieceState == PieceState.Open)
                        {
                            // if spot is where user wants to go
                            if (rowTo == row && colTo == col)
                            {
                                // spot is valid
                                return true;
                            }
                        }

                        // spot is invalid
                        break;
                    }
                }
            }

            // not a valid placement
            return false;
        }
        
        
        
        List<List<int>> GetPieces(PieceState chosen){
            var pieces = new List<List<int>>();

            for (var row = 0; row <= 7; row++)
            {
                for (var col = 0; col <= 7; col++)
                {
                    var currPiece = GameBoard.GameBoard[row, col].PieceState;

                    if (currPiece == chosen)
                    {
                        var coordinate = new List<int>();
                        coordinate.Add(row);
                        coordinate.Add(col);
                        pieces.Add(coordinate);
                    }
                        
                }
            }

            return pieces;
        }

        
        
    }
}