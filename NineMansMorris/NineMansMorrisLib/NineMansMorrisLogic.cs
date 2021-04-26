using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;

namespace NineMansMorrisLib
{
    public class NineMansMorrisLogic
    {
        public Board GameBoard { get; private set; }
        public Player WhitePlayer { get; private set; }
        public Player BlackPlayer { get; private set; }
        
        public bool GameOver { get; private set; }

       

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
            if (GameOver) return false;
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
            if (GameOver) return false;
            // if invalid placement and not all pieces placed return
            if (!LogicHelper.IsValid(rowTo, colTo, rowFrom, colFrom) || !player.AllPiecesPlaced) return false;
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


        // pre : 
        public bool RemovePiece(Player player, int row, int col)
        {
            if (GameOver) return false;
            // if invalid return false
            if (GameBoard.GameBoard[row, col].PieceState == PieceState.Invalid) return false;
            // fix this opposite player check if pieces remaining equals pieces left

            var oppositePlayer = player == BlackPlayer ? WhitePlayer : BlackPlayer;

            if (GameBoard.GameBoard[row, col].MillState == MillState.Milled &&
                (oppositePlayer.PiecesInPlay != oppositePlayer.MilledPieces || !oppositePlayer.AllPiecesPlaced))
                return false;
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

            return false;
        }

        
        
        // pre : 
        public bool FlyPiece(Player player, int rowTo, int colTo, int rowFrom, int colFrom)
        {
            if (GameOver) return false;
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

     

        // pre :
        public bool CheckMill(int row, int col, Player player)
        {
            var lists = LogicHelper.GetMills(row, col);

            //Sets mills if any.
            if (lists["row"].Count == 3 || lists["col"].Count == 3)
            {
                if (lists["row"].Count == 3)
                {
                    foreach (var piece in lists["row"])
                    {
                        piece.MillState = MillState.Milled;
                        player.MillPiece();
                    }
                }

                if (lists["col"].Count == 3)
                {
                    foreach (var piece in lists["col"])
                    {
                        piece.MillState = MillState.Milled;
                        player.MillPiece();
                    }
                }

                return true;
            }

            //No mills found, return false.
            return false;
        }
        // post :

        
   
        // pre :
        public bool CheckIfMovementNotPossible(Player player)
        {
            foreach( var a in player.coordinateList)
            {
                foreach (var direction in LogicHelper.Directions)
                {
                    // while move is not possible
                    var row = a[0];
                    var col = a[1];
                    while (true)
                    {
                        // update position
                        row += direction.Value[0];
                        a[1] += direction.Value[1];

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
                                return false;
                            }

                            // spot is invalid
                            break;
                        }
                    }
                }
                }
            
            return true;
        }
        // post :
    }
}