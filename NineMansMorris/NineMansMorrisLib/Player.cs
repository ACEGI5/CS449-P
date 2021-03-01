namespace NineMansMorrisLib
{
    public class Player
    {
        public int piecesToPlace = 9;
        public int piecesInPlay = 0;
        public bool allPiecesPlaced = false;
        public char playerColor;

        // Checks if a player has only three pieces left.
        // If so, player may begin flying pieces.
        // Output: bool representing if player can fly.
        public bool playerCanFly()
        {
            return (piecesInPlay == 3 && allPiecesPlaced);
        }
        
        
    }
}