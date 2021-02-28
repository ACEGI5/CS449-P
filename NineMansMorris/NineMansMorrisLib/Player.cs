namespace NineMansMorrisLib
{
    public class Player
    {
        public char playerColor;
        public int unplacedPieces;
        public int piecesInPlay;
        private bool canFly = false;

        public void flyPieces()
        {
            
        }

        public void isThreePieces()
        {
            if (piecesInPlay == 3)
            {
                canFly = true;
            }
        }
        
    }
}