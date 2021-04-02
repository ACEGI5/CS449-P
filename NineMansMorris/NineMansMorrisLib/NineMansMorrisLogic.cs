using System;
using System.Collections;
using System.Collections.Generic;

namespace NineMansMorrisLib
{
    
    public class NineMansMorrisLogic
    {
        
        public Board GameBoard { get; private set; }
        public Player WhitePlayer { get; private set; }
        public Player BlackPlayer { get; private set; }
        
        private Dictionary<string, int[]> directions = new Dictionary<string, int[]>()
        {
                
            {"up", new int[] {-1, 0}}, {"down", new int[] {1, 0}},
            {"left", new int[] {0, -1}}, {"right", new int[] {0, 1}}

        };

        public NineMansMorrisLogic()
        {
            
            GameBoard = new Board();
            WhitePlayer = new Player();
            BlackPlayer = new Player();
            
        }
        
        // pre : 
        public bool PlacePiece(Player player, int row, int col)
        {

            // if not all pieces place and spot is valid
            if (!player.AllPiecesPlaced && GameBoard.GameBoard[row, col].PieceState == PieceState.Open)
            {

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

            }

            // events have not taken place
            return false;

        }
        // post : 

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
                
                // events have taken place
                return true;

            }

            // events have not taken place
            return false;
            
        }
        // post : 
        
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

                                // spot is valid
                                return true;

                            }

                        }

                        // spot is invalid
                        return false;

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

            // if black, white, open
            if (GameBoard.GameBoard[row, col].PieceState != PieceState.Invalid)
            {

                // if white and removing opponent piece
                if (player == WhitePlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.Black)
                {

                    // update
                    WhitePlayer.RemovePiece();
                    GameBoard.GameBoard[row, col].PieceState = PieceState.Open;
                    
                    // events have taken place
                    return true;

                }

                // if black and removing opponent piece
                if (player == BlackPlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.White)
                {

                    // update
                    BlackPlayer.RemovePiece();
                    GameBoard.GameBoard[row, col].PieceState = PieceState.Open;
                    
                    // events have taken place
                    return true;

                }
                
            }

            // events have not taken place
            return false;

        }
        
        // pre : 
        public bool FlyPiece(Player player, int rowTo, int colTo, int rowFrom, int colFrom)
        {

            // if player can fly
            if (player.CanFly())
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
                
                // events have taken place
                return true;

            }

            // events have not taken place
            return false;

        }
        // post : 

    }
}