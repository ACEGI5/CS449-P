using System;
using System.Data;

namespace NineMansMorrisLib
{
    public class NineMansMorrisLogic
    {
        //turn 0 white turn 1 black(this should be enum)
        public int Turn { get; private set; }
        public Player WhitePlayer { get; private set; }
        public Player BlackPlayer { get; private set; }

        public Board GameBoard { get; private set; }

        public NineMansMorrisLogic()
        {
            var rnd = new Random();
            Turn = rnd.Next(0, 2);
            WhitePlayer = new Player();
            BlackPlayer = new Player();
            GameBoard = new Board();
        }

        public void MovePiece(Player player, int newRow, int newCol, int oldRow, int oldCol)
        {
          
        }

        public void FlyPiece(Player player, int newRow, int newCol, int oldRow, int oldCol)
        {
            
        }

        public void PlacePiece(Player player, int row, int col)
        {
            if (player == WhitePlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.Open &&
                WhitePlayer.AllPiecesPlaced == false)
            {
                WhitePlayer.PlacePiece();
                GameBoard.GameBoard[row, col].PieceState = PieceState.White;
            }
            else if (player == BlackPlayer && GameBoard.GameBoard[row, col].PieceState == PieceState.Open &&
                     BlackPlayer.AllPiecesPlaced == false)
            {
                BlackPlayer.PlacePiece();
                GameBoard.GameBoard[row, col].PieceState = PieceState.Black;
            }
        }

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
                    MovePiece(WhitePlayer, newRow,  newCol, oldRow, oldCol);

                }
                else if (WhitePlayer.PlayerCanFly())
                {
                    FlyPiece(WhitePlayer, newRow,  newCol, oldRow, oldCol);

                }
                //check mill function then -> prompt for player to select which opp piece to mill 
                Turn = 1;
            }
            else if(Turn == 1)
            {
                //Black Player
                if (WhitePlayer.PiecesToPlace != 0)
                {
                    PlacePiece(WhitePlayer, newRow, newCol);
                }
                else if (!WhitePlayer.PlayerCanFly())
                {
                    MovePiece(WhitePlayer, newRow,  newCol, oldRow, oldCol);

                }
                else if (WhitePlayer.PlayerCanFly())
                {
                    FlyPiece(WhitePlayer, newRow,  newCol, oldRow, oldCol);

                }
                //check mill function then -> prompt for player to select which opp piece to mill  
                Turn = 0;
            }
        }
        
        
    }
}