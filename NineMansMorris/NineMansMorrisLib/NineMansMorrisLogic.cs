using System;

namespace NineMansMorrisLib
{
    public class NineMansMorrisLogic
    {
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

        public void MovePiece(Player player, int oldRow, int oldColumn, int newRow, int newColumn)
        {
            if (player.PlayerCanFly())
            {
            }
            else
            {
            }
        }

        public void PlacePiece(Player player, int row, int column)
        {
        }

        public void TakeTurn(Player player)
        {
        }


        //gabe reallly do suck
    }
}