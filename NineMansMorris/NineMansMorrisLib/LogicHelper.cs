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

        
        
        public void UpdateCoordinateList(Player blackPlayer, Player whitePlayer)
        {
            for (var row = 0; row <= 7; row++)
            {
                for (var col = 0; col <= 7; col++)
                {
                    var coordinate = new List<int>();
                    coordinate.Add(row);
                    coordinate.Add(col);
                    var color = GameBoard.GameBoard[row, col].PieceState;

                    switch (color)
                    {
                        case PieceState.Black:
                            blackPlayer.coordinateList.Add(coordinate);
                            break;
                        case PieceState.White:
                            whitePlayer.coordinateList.Add(coordinate);
                            break;
                    }
                }
            }
        }

        
        
        public static Dictionary<string, List<GamePiece>> GetMills(int row, int col)
        {
            var currPieceState = GameBoard.GameBoard[row, col].PieceState;
            var rowList = new List<GamePiece>();
            var colList = new List<GamePiece>();
            var lists = new Dictionary<string, List<GamePiece>>()
            {
                {"row", rowList},
                {"col", colList}
            };
            PieceState validPieceState;
            //If PieceState is not Black or White, return false.
            switch (currPieceState)
            {
                case PieceState.Black:
                    validPieceState = PieceState.Black;
                    break;
                case PieceState.White:
                    validPieceState = PieceState.White;
                    break;
                default:
                    return lists;
            }

            if (row == 3 || col == 3)
            {
                for (var i = 0; i <= 6; i++)
                {
                    //If position MIDDLE (3,3) is hit, reset the matching list.
                    switch (i)
                    {
                        case 3 when row == 3 && col > 3:
                            lists["row"].Clear();
                            break;
                        case 3 when col == 3 && row > 3:
                            lists["col"].Clear();
                            break;
                    }

                    if (GameBoard.GameBoard[row, i].PieceState == validPieceState)
                    {
                        if (!(col < 3 && i > 3))
                            lists["row"].Add(GameBoard.GameBoard[row, i]);
                    }

                    if (GameBoard.GameBoard[i, col].PieceState == validPieceState)
                    {
                        if (!(row < 3 && i > 3))
                            lists["col"].Add(GameBoard.GameBoard[row, i]);
                    }
                }
            }
            else
            {
                //Search for Mills.
                for (var i = 0; i <= 6; i++)
                {
                    if (GameBoard.GameBoard[row, i].PieceState == validPieceState)
                    {
                        lists["row"].Add(GameBoard.GameBoard[row, i]);
                    }

                    if (GameBoard.GameBoard[i, col].PieceState == validPieceState)
                    {
                        lists["col"].Add(GameBoard.GameBoard[row, i]);
                    }
                }
            }

            return lists;
        }
        
        
        
        public void RemoveMill(int row, int col, Player player)
        {
            var lists = LogicHelper.GetMills(row, col);

            //Remove mills if any.
            if (lists["row"].Count == 3 || lists["col"].Count == 3)
            {
                if (lists["row"].Count == 3)
                {
                    foreach (var piece in lists["row"])
                    {
                        piece.MillState = MillState.NotMilled;
                    }
                    player.BreakMilledPiece();
                }

                if (lists["col"].Count == 3)
                {
                    foreach (var piece in lists["col"])
                    {
                        piece.MillState = MillState.NotMilled;
                    }
                    player.BreakMilledPiece();
                }
            }
        }
        
        
        
        

    }
    
    
    
    
    
    
    
}