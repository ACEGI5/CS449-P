using System.Collections.Generic;

namespace NineMansMorrisLib
{
    public class NineMansMorrisLogic
    {
        public Board GameBoard { get; private set; }
        public Player WhitePlayer { get; private set; }
        public Player BlackPlayer { get; private set; }
        public bool GameOver { get; private set; }

        private Dictionary<string, int[]> directions = new Dictionary<string, int[]>
        {
            {"up", new[] {-1, 0}}, {"down", new[] {1, 0}},
            {"left", new[] {0, -1}}, {"right", new[] {0, 1}}
        };

        public NineMansMorrisLogic()
        {
            GameBoard = new Board();
            WhitePlayer = new Player();
            BlackPlayer = new Player();
            GameOver = false;
        }

        // pre : 
        public bool PlacePiece(Player player, int row, int col)
        {
            // if player has all pieces placed or where they are placing is not valid return false
            if (player.AllPiecesPlaced || GameBoard.GameBoard[row, col].PieceState != PieceState.Open) return false;
            // if white
            if (player == WhitePlayer)
            {
                // update
                WhitePlayer.PlacePiece();
                GameBoard.GameBoard[row, col].PieceState = PieceState.White;
            }

            // if black
            else
            {
                // update
                BlackPlayer.PlacePiece();
                GameBoard.GameBoard[row, col].PieceState = PieceState.Black;
            }

            // events have taken place
            return true;

            // events have not taken place
        }
        // post : 

        // pre : 
        public bool MovePiece(Player player, int rowTo, int colTo, int rowFrom, int colFrom)
        {
            // if invalid placement and not all pieces placed return
            if (!isValid(rowTo, colTo, rowFrom, colFrom) || !player.AllPiecesPlaced) return false;
            //if mill broken
            if (GameBoard.GameBoard[rowFrom, colFrom].MillState == MillState.Milled)
            {
             
                    player.BreakMilledPiece();
            }

            // if white
            if (player == WhitePlayer)
            {
                // update
                GameBoard.GameBoard[rowTo, colTo].PieceState = PieceState.White;
                GameBoard.GameBoard[rowFrom, colFrom].PieceState = PieceState.Open;
            }

            // if black
            else
            {
                // update
                GameBoard.GameBoard[rowTo, colTo].PieceState = PieceState.Black;
                GameBoard.GameBoard[rowFrom, colFrom].PieceState = PieceState.Open;
            }

            // events have taken place
            return true;

            // events have not taken place
        }
        // post : 

        private bool isValid(int rowTo, int colTo, int rowFrom, int colFrom)
        {
            // traverse each direction
            foreach (var direction in directions)
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
        // post : 

        // pre : 
        public bool RemovePiece(Player player, int row, int col)
        {
            // if invalid return false
            if (GameBoard.GameBoard[row, col].PieceState == PieceState.Invalid) return false;

            if (GameBoard.GameBoard[row, col].MillState != MillState.Milled ||
                player.PiecesInPlay == player.MilledPieces)
            {
                if (GameBoard.GameBoard[row, col].MillState == MillState.Milled)
                {
                    
                        player.BreakMilledPiece();
                    
                }

                // if white and removing opponent piece
                if (player == WhitePlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.Black)
                {
                    // update
                    BlackPlayer.RemovePiece();
                    GameOver = BlackPlayer.PlayerHasLost();
                    GameBoard.GameBoard[row, col].PieceState = PieceState.Open;

                    // events have taken place
                    return true;
                }

                // if black and removing opponent piece
                if (player == BlackPlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.White)
                {
                    // update
                    WhitePlayer.RemovePiece();
                    GameOver = WhitePlayer.PlayerHasLost();
                    GameBoard.GameBoard[row, col].PieceState = PieceState.Open;

                    // events have taken place
                    return true;
                }
            }

            return false;
        }

        // pre : 
        public bool FlyPiece(Player player, int rowTo, int colTo, int rowFrom, int colFrom)
        {
            // if player can't fly return
            if (!player.CanFly()) return false;
            // if invalid fly return false
            if (GameBoard.GameBoard[rowTo, colTo].PieceState != PieceState.Open ||
                GameBoard.GameBoard[rowTo, colTo].PieceState == PieceState.Invalid) return false;
            //if mill is broken
            if (GameBoard.GameBoard[rowFrom, colFrom].MillState == MillState.Milled)
            {
                
                    player.BreakMilledPiece();
                
            }

            //white player
            if (player == WhitePlayer)
            {
                // update
                GameBoard.GameBoard[rowTo, colTo].PieceState = PieceState.White;
                GameBoard.GameBoard[rowFrom, colFrom].PieceState = PieceState.Open;
            }

            // if black
            else
            {
                // update
                GameBoard.GameBoard[rowTo, colTo].PieceState = PieceState.Black;
                GameBoard.GameBoard[rowFrom, colFrom].PieceState = PieceState.Open;
            }


            // events have taken place
            return true;
        }

        // post : 

        public bool CheckMill(int row, int col, Player player)
        {
            var currPieceState = GameBoard.GameBoard[row, col].PieceState;
            var rowCounter = 0;
            var colCounter = 0;
            PieceState validPieceState;
            if (currPieceState == PieceState.Black) validPieceState = PieceState.Black;
            else if (currPieceState == PieceState.White) validPieceState = PieceState.White;
            else return false;

            for (var i = 0; i <= 6; i++)
            {
                if (i == 3 && row == 3)
                    rowCounter = 0;
                if (i == 3 && col == 3)
                    colCounter = 0;

                if (GameBoard.GameBoard[row, i].PieceState == validPieceState)
                {
                    rowCounter += 1;
                }

                if (GameBoard.GameBoard[i, col].PieceState == validPieceState)
                {
                    colCounter += 1;
                }

                if (rowCounter == 3 || colCounter == 3)
                {
                    GameBoard.GameBoard[row, col].MillState = MillState.Milled;
                    for (var j = 0; j < 3; j++)
                    {
                        player.MillPiece(); 
                    }
                    return true;
                }
            }
//aa
            return false;
        }
        
    }
    
}