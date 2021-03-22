using System;

namespace NineMansMorrisLib
{
    public class NineMansMorrisLogic
    {
        public int Turn { get; private set; }
        public Player WhitePlayer { get; private set; }
        public Player BlackPlayer { get; private set; }

        public Board GameBoard { get; private set; }

        // 
        public NineMansMorrisLogic()
        {
            var rnd = new Random();
            Turn = rnd.Next(0, 2);
            WhitePlayer = new Player();
            BlackPlayer = new Player();
            GameBoard = new Board();
        }

        // 
        public void MovePiece(Player player, int newRow, int newCol, int oldRow, int oldCol)
        {
            if (player == WhitePlayer && GameBoard.GameBoard[newRow, newCol].PieceState == PieceState.Open &&
                WhitePlayer.AllPiecesPlaced && CheckIfAdjacent(newRow, newCol, oldRow, oldCol))
            {
                GameBoard.GameBoard[newRow, newCol].PieceState = PieceState.White;
                GameBoard.GameBoard[oldRow, oldCol].PieceState = PieceState.Open;
            }

            else if (player == BlackPlayer && GameBoard.GameBoard[newRow, newCol].PieceState == PieceState.Open &&
                     WhitePlayer.AllPiecesPlaced && CheckIfAdjacent(newRow, newCol, oldRow, oldCol))
            {
                GameBoard.GameBoard[newRow, newCol].PieceState = PieceState.Black;
                GameBoard.GameBoard[oldRow, oldCol].PieceState = PieceState.Open;
            }
        }

        // 
        public void FlyPiece(Player player, int newRow, int newCol, int oldRow, int oldCol)
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
        public void PlacePiece(Player player, int row, int col)
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

        // 
        public void TakeTurn(Player player, int newRow, int newCol, int oldRow, int oldCol)
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
                Turn = 0;
            }
        }

        // this method was moved from Board.cs
        // this method has changed from public to private
        private bool CheckIfAdjacent(int newRow, int newCol, int oldRow, int oldCol)
        {
            return (Math.Abs(newRow - oldRow) + Math.Abs(newCol - oldCol)) == 1;
        }
    }
}