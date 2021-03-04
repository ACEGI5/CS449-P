
using System;

namespace NineMansMorrisLib
{
    public class NineMansMorrisLogic
    {
        private int _turn;
        private Player _whitePlayer;
        private Player _blackPlayer;
        private Board _gameBoard;
        public NineMansMorrisLogic()
        {
            Random rnd = new Random();
            _turn = rnd.Next(0, 2);
            _whitePlayer = new Player();
            _blackPlayer = new Player();
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
        public void PlacePiece(Player player)
        {
            
        }
        public void TakeTurn(Player player)
        {
            
        }
        
        
        
        
        //gabe reallly do suck
    }
}