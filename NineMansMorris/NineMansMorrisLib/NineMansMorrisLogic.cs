using System;
using System.Collections;
using System.Collections.Generic;

namespace NineMansMorrisLib
{
    public class NineMansMorrisLogic
    {
        public int Turn { get; private set; }
        public Player WhitePlayer { get; private set; }
        public Player BlackPlayer { get; private set; }

        public Board GameBoard { get; private set; }
        
        private Dictionary<string, int[]> _directions = new Dictionary<string, int[]>()
        {
                
            {"up", new int[] {-1, 0}}, {"down", new int[] {1, 0}},
            {"left", new int[] {0, -1}}, {"right", new int[] {0, 1}}

        };

        // 
        public NineMansMorrisLogic()
        {
            var rnd = new Random();
            Turn = rnd.Next(0, 2);
            WhitePlayer = new Player();
            BlackPlayer = new Player();
            GameBoard = new Board();
        }

        // Needs rewriting with new isAdjacent method
        private void MovePiece(Player player, int newRow, int newCol, int oldRow, int oldCol)
        {
            Hashtable validMoves = CheckIfAdjacent(oldRow, oldCol);
            
            if (player == WhitePlayer && GameBoard.GameBoard[newRow, newCol].PieceState == PieceState.Open &&
                WhitePlayer.AllPiecesPlaced && IsValidMove(validMoves, newRow, newCol))
            {
                GameBoard.GameBoard[newRow, newCol].PieceState = PieceState.White;
                GameBoard.GameBoard[oldRow, oldCol].PieceState = PieceState.Open;
            }

            else if (player == BlackPlayer && GameBoard.GameBoard[newRow, newCol].PieceState == PieceState.Open &&
                     WhitePlayer.AllPiecesPlaced && IsValidMove(validMoves, newRow, newCol))
            {
                GameBoard.GameBoard[newRow, newCol].PieceState = PieceState.Black;
                GameBoard.GameBoard[oldRow, oldCol].PieceState = PieceState.Open;
            }
        }

        // 
        private void FlyPiece(Player player, int newRow, int newCol, int oldRow, int oldCol)
        {

            // Checks if it's white players' turn and if the chosen position is open.
            if (player == WhitePlayer && GameBoard.GameBoard[newRow, newCol].PieceState == PieceState.Open)
            {
                // Places white in the new position and makes the old position open.
                GameBoard.GameBoard[newRow, newCol].PieceState = PieceState.White;
                GameBoard.GameBoard[oldRow, oldCol].PieceState = PieceState.Open;
                Turn = 1;
            }

            // Checks if it's white players' turn and if the chosen position is open.
            else if (player == BlackPlayer && GameBoard.GameBoard[newRow, newCol].PieceState == PieceState.Open)
            {
                // Places black in the new position and makes the old position open.
                GameBoard.GameBoard[newRow, newCol].PieceState = PieceState.Black;
                GameBoard.GameBoard[oldRow, oldCol].PieceState = PieceState.Open;
                Turn = 0;
            }
        }

        // 
        private void PlacePiece(Player player, int row, int col)
        {
            // checks if it is white player's turn and if
            // this condition was adjusted with regards to isAdjacent
            if (player == WhitePlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.Open &&
                WhitePlayer.AllPiecesPlaced == false)
            {
                WhitePlayer.PlacePiece();
                GameBoard.GameBoard[row, col].PieceState = PieceState.White;
                Turn = 1;
            }

            // this condition was adjusted with regards to isAdjacent
            else if (player == BlackPlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.Open &&
                     BlackPlayer.AllPiecesPlaced == false)
            {
                BlackPlayer.PlacePiece();
                GameBoard.GameBoard[row, col].PieceState = PieceState.Black;
                Turn = 0;
            }
        }

        // old row and column are optional parameters for place piece condition with default set to negative one, when game stage is in movement or fly values will be passed in from UI
        public void TakeTurn(Player player, int newRow, int newCol, int oldRow=-1, int oldCol=-1)
        {
            if (Turn == 0)
            {
                //WhitePlayer
                if (WhitePlayer.PiecesToPlace != 0)
                {
                    PlacePiece(WhitePlayer, newRow, newCol);
                }

                else if (!WhitePlayer.PlayerCanFly())
                {
                    MovePiece(WhitePlayer, newRow, newCol, oldRow, oldCol);
                }

                else if (WhitePlayer.PlayerCanFly())
                {
                    FlyPiece(WhitePlayer, newRow, newCol, oldRow, oldCol);
                }

                //check mill function then -> prompt for player to select which opp piece to mill 
                Turn = 1;
            }

            else if (Turn == 1)
            {
                //Black Player
                if (BlackPlayer.PiecesToPlace != 0)
                {
                    PlacePiece(BlackPlayer, newRow, newCol);
                }

                else if (!BlackPlayer.PlayerCanFly())
                {
                    MovePiece(BlackPlayer, newRow, newCol, oldRow, oldCol);
                }

                else if (BlackPlayer.PlayerCanFly())
                {
                    FlyPiece(BlackPlayer, newRow, newCol, oldRow, oldCol);
                }

                //check mill function then -> prompt for player to select which opp piece to mill  
                Turn = 0;
            }
        }

        // this method was moved from Board.cs
        // this method has changed from public to private
        private Hashtable CheckIfAdjacent(int curRow, int curCol)
        {
            // Board needs accessor to allow this class to get the board size.
            Hashtable validMoves = new Hashtable();
            
            validMoves.Add("left", new Tuple<int, int>(-1, -1));
            validMoves.Add("right", new Tuple<int, int>(-1, -1));
            validMoves.Add("up", new Tuple<int, int>(-1, -1));
            validMoves.Add("down", new Tuple<int, int>(-1, -1));

            int temp;
            
            // Checks case where piece isn't on far left and finds valid move on the left
            if (curRow > 0)
            {
                temp = curRow - 1;
                while (temp >= 0)
                {
                    // if the first valid spot that is encountered is open, then the left position is set and the loop is broken
                    if (GameBoard.GameBoard[temp, curCol].PieceState == PieceState.Open)
                    {
                        validMoves["up"] = new Tuple<int, int>(temp, curCol);
                        break;
                    }
                    // if spot is invalid, then keep traversing the board to find a valid spot
                    else if (GameBoard.GameBoard[temp, curCol].PieceState == PieceState.Invalid)
                    {
                        temp--;
                    }
                    // otherwise, the spot is valid and occupied, and thus can't be moved to
                    else
                    {
                        break;
                    }
                }
            }

            // Checks case where piece isn't on far right and finds valid move
            if (curRow < 6)
            {
                temp = curRow + 1;
                while (temp < 7)
                {
                    // if the first valid spot that is encountered is open, then the right position is set and the loop is broken
                    if (GameBoard.GameBoard[temp, curCol].PieceState == PieceState.Open)
                    {
                        validMoves["down"] = new Tuple<int, int>(temp, curCol);
                        break;
                    }
                    // if spot is invalid, then keep traversing the board to find a valid spot
                    else if (GameBoard.GameBoard[temp, curCol].PieceState == PieceState.Invalid)
                    {
                        temp++;
                    }
                    // otherwise, the spot is valid and occupied, and thus can't be moved to
                    else
                    {
                        break;
                    }
                }
            }
            
            // Checks case where piece isn't at top and finds valid move
            if (curCol > 0)
            {
                temp = curCol - 1;
                while (temp >= 0)
                {
                    // if the first valid spot that is encountered is open, then the up position is set and the loop is broken
                    if (GameBoard.GameBoard[curRow, temp].PieceState == PieceState.Open)
                    {
                        validMoves["left"] = new Tuple<int, int>(curRow, temp);
                        break;
                    }
                    // if spot is invalid, then keep traversing the board to find a valid spot
                    else if (GameBoard.GameBoard[curRow, temp].PieceState == PieceState.Invalid)
                    {
                        temp--;
                    }
                    // otherwise, the spot is valid and occupied, and thus can't be moved to
                    else
                    {
                        break;
                    }
                }
            }
            
            // Checks case where piece isn't at bottom and finds valid move
            
            if (curCol < 6)
            {
                temp = curCol + 1;
                while (temp < 7)
                {
                    // if the first valid spot that is encountered is open, then the down position is set and the loop is broken
                    if (GameBoard.GameBoard[curRow, temp].PieceState == PieceState.Open)
                    {
                        validMoves["right"] = new Tuple<int, int>(curRow, temp);
                        break;
                    }
                    // if spot is invalid, then keep traversing the board to find a valid spot
                    else if (GameBoard.GameBoard[curRow, temp].PieceState == PieceState.Invalid)
                    {
                        temp++;
                    }
                    // otherwise, the spot is valid and occupied, and thus can't be moved to
                    else
                    {
                        break;
                    }
                }
            }

            return validMoves;
        }

        private bool IsValidMove(Hashtable validMoves, int newRow, int newCol)
        {
    Console.WriteLine(validMoves.ContainsValue(new Tuple<int, int>(newRow, newCol))); // Naive test
            return validMoves.ContainsValue(new Tuple<int, int>(newRow, newCol));
        }
    }
}