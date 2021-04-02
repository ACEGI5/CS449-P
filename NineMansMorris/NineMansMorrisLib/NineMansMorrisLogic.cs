using System;
using System.Collections;
using System.Collections.Generic;

namespace NineMansMorrisLib
{
    
    public class NineMansMorrisLogic
    {
        
        //public int Turn { get; private set; }
        public Player WhitePlayer { get; private set; }
        public Player BlackPlayer { get; private set; }

        public Board GameBoard { get; private set; }
        
        private Dictionary<string, int[]> directions = new Dictionary<string, int[]>()
        {
                
            {"up", new int[] {-1, 0}}, {"down", new int[] {1, 0}},
            {"left", new int[] {0, -1}}, {"right", new int[] {0, 1}}

        };

        public NineMansMorrisLogic()
        {
            
            WhitePlayer = new Player();
            BlackPlayer = new Player();
            GameBoard = new Board();
            
        }

        // pre : 
        public bool MovePiece(Player player, int rowTo, int colTo, int rowFrom, int colFrom)
        {
            
            // if valid placement and all pieces placed
            if (isValid(rowTo, colTo, rowFrom, colFrom) && player.AllPiecesPlaced)
            {

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
                
                // events were successful
                return true;

            }

            // events were not successful
            return false;
            
        }
        // post : 
        
        // pre : 
        public bool FlyPiece(Player player, int rowTo, int colTo, int rowFrom, int colFrom)
        {

            // if player can fly
            if (player.PlayerCanFly())
            {

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
                
                // events were successful
                return true;

            }

            // events were not successful
            return false;

        }
        // post : 

        public void PlacePiece(Player player, int row, int col)
        {
            
            // checks if it is white player's turn and if
            // this condition was adjusted with regards to isAdjacent
            if (player == WhitePlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.Open &&
                WhitePlayer.AllPiecesPlaced == false)
            {
                
                WhitePlayer.PlacePiece();
                GameBoard.GameBoard[row, col].PieceState = PieceState.White;
                //Turn = 1;
                
            }

            // this condition was adjusted with regards to isAdjacent
            else if (player == BlackPlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.Open &&
                     BlackPlayer.AllPiecesPlaced == false)
            {
                
                BlackPlayer.PlacePiece();
                GameBoard.GameBoard[row, col].PieceState = PieceState.Black;
                //Turn = 0;
                
            }
            
        }

        // 
        public void TakeTurn(Player player, int newRow, int newCol, int oldRow, int oldCol)
        {
            
            //if (Turn == 0)
            {
                
                //WhitePlayer
                if (WhitePlayer.PiecesToPlace != 0)
                {
                    
                    PlacePiece(WhitePlayer, newRow, newCol);
                    
                }

                else if (!WhitePlayer.PlayerCanFly())
                {
                    
                    //MovePiece(WhitePlayer, newRow, newCol, oldRow, oldCol);
                    
                }

                else if (WhitePlayer.PlayerCanFly())
                {
                    
                    FlyPiece(WhitePlayer, newRow, newCol, oldRow, oldCol);
                    
                }

                //check mill function then -> prompt for player to select which opp piece to mill 
                //Turn = 1;
                
            }

            else if (//Turn == 1)
            {
                
                //Black Player
                if (WhitePlayer.PiecesToPlace != 0)
                {
                    
                    PlacePiece(WhitePlayer, newRow, newCol);
                    
                }

                else if (!WhitePlayer.PlayerCanFly())
                {
                    
                    //MovePiece(WhitePlayer, newRow, newCol, oldRow, oldCol);
                    
                }

                else if (WhitePlayer.PlayerCanFly())
                {
                    
                    FlyPiece(WhitePlayer, newRow, newCol, oldRow, oldCol);
                    
                }

                //check mill function then -> prompt for player to select which opp piece to mill  
                //Turn = 0;
                
            }
            
        }

        // pre : 
        private bool isValid(int rowTo, int colTo, int rowFrom, int colFrom)
        {

            // traverse each direction
            foreach (KeyValuePair<string, int[]> direction in directions)
            {

                // while move is not possible
                while (true)
                {

                    // update position
                    int row = rowFrom + direction.Value[0];
                    int col = colFrom + direction.Value[1];

                    // if out of bounds
                    if ((row < 10 && col < 10) && (col > -1) && (row > -1))
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

                                return true;

                            }

                        }

                        return false;

                    }

                }
                
            }

            return false;

        }
        // post : 
        
    }
}