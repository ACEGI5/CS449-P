using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using NineMansMorrisLib;

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

        private bool isValid(int rowTo, int colTo, int rowFrom, int colFrom)
        {
            // traverse each direction
            foreach (KeyValuePair<string, int[]> direction in directions)
            {
                // while move is not possible
                int row = rowFrom;
                int col = colFrom;
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
            // if black, white, open
            if (GameBoard.GameBoard[row, col].PieceState != PieceState.Invalid)
            {
                // if white and removing opponent piece
                if (player == WhitePlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.Black)
                {
                    // update
                    BlackPlayer.RemovePiece();
                    GameBoard.GameBoard[row, col].PieceState = PieceState.Open;

                    // events have taken place
                    return true;
                }

                // if black and removing opponent piece
                if (player == BlackPlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.White)
                {
                    // update
                    WhitePlayer.RemovePiece();
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
            if (!player.CanFly()) return false;
            // if white
            if (GameBoard.GameBoard[rowTo, colTo].PieceState != PieceState.Open ||
                GameBoard.GameBoard[rowTo, colTo].PieceState == PieceState.Invalid) return false;
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

        public bool CheckMill(int row, int col)
        {
            var currPieceState = GameBoard.GameBoard[row, col].PieceState;
            int rowCounter = 0;
            int colCounter = 0;
            PieceState validPieceState;
            PieceState validMilledPieceState;
            if (currPieceState == PieceState.Black|| currPieceState==PieceState.BlackMilled)
            {
                validPieceState = PieceState.Black;
                validMilledPieceState = PieceState.BlackMilled;
            }
            else if (currPieceState == PieceState.White|| currPieceState==PieceState.WhiteMilled)
            {
                validPieceState = PieceState.White;
                validMilledPieceState = PieceState.WhiteMilled;
            }
            else
            {
                return false;
            }

            //if current piece is not in the middle column or row we can traverse the entire column or row
            //and as long as there are a total of three pieces of the same color there is a mill
            if (row != 3 && col != 3)
            {
                for (int i = 0; i <= 6; i++)
                {
                    if (GameBoard.GameBoard[row, i].PieceState == validPieceState ||
                        GameBoard.GameBoard[row, i].PieceState == validMilledPieceState)
                    {
                        rowCounter += 1;
                    }

                    if (GameBoard.GameBoard[i, col].PieceState == validPieceState ||
                        GameBoard.GameBoard[i, col].PieceState == validMilledPieceState)
                    {
                        colCounter += 1;
                    }
                }

                if (rowCounter == 3 || colCounter == 3)
                {
                    if (GameBoard.GameBoard[row, col].PieceState == PieceState.Black)
                    {
                        GameBoard.GameBoard[row, col].PieceState = PieceState.BlackMilled;
                    }
                    else if (GameBoard.GameBoard[row, col].PieceState == PieceState.White)
                    {
                        GameBoard.GameBoard[row, col].PieceState = PieceState.WhiteMilled;
                    }

                    return true;
                }
            }
            //if the current piece is in the middle we effectively split the board in half and
            //traverse the half that the current piece is in adding total number of pieces of the current color
            else if (row == 3 || col == 3)
            {
                if (row < 3 || col < 3)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (GameBoard.GameBoard[row, i].PieceState == validPieceState ||
                            GameBoard.GameBoard[row, i].PieceState == validMilledPieceState)
                        {
                            rowCounter += 1;
                        }

                        if (GameBoard.GameBoard[i, col].PieceState == validPieceState ||
                            GameBoard.GameBoard[i, col].PieceState == validMilledPieceState)
                        {
                            colCounter += 1;
                        }
                    }
                }
                else if (row > 3 || col > 3)
                {
                    for (int i = 3; i <= 6; i++)
                    {
                        if (GameBoard.GameBoard[row, i].PieceState == validPieceState ||
                            GameBoard.GameBoard[row, i].PieceState == validMilledPieceState)
                        {
                            rowCounter += 1;
                        }

                        if (GameBoard.GameBoard[i, col].PieceState == validPieceState ||
                            GameBoard.GameBoard[i, col].PieceState == validMilledPieceState)
                        {
                            colCounter += 1;
                        }
                    }
                }

                if (rowCounter == 3 || colCounter == 3)
                {
                    if (GameBoard.GameBoard[row, col].PieceState == PieceState.Black)
                    {
                        GameBoard.GameBoard[row, col].PieceState = PieceState.BlackMilled;
                    }
                    else if (GameBoard.GameBoard[row, col].PieceState == PieceState.White)
                    {
                        GameBoard.GameBoard[row, col].PieceState = PieceState.WhiteMilled;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}