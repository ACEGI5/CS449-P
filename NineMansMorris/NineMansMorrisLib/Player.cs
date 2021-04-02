namespace NineMansMorrisLib
{
    
    public class Player
    {

        public int PiecesInPlay { get; private set; }
        public int PiecesToPlace { get; private set; }
        public bool AllPiecesPlaced { get; private set; }

        public Player()
        {
            
            PiecesToPlace = 9;
            PiecesInPlay = 0;
            AllPiecesPlaced = false;
            
        }

        // Checks if a player has only three pieces left.
        // If so, player may begin flying pieces.
        // Output: bool representing if player can fly.
        public bool CanFly()
        {
            
            return (PiecesInPlay == 3 && AllPiecesPlaced);
            
        }

        public void PlacePiece()
        {
            
            PiecesInPlay += 1;
            PiecesToPlace += 1;

            if (PiecesToPlace == 0)
            {

                AllPiecesPlaced = true;

            }

        }

        public bool PlayerHasLost()
        {
            
            return ((PiecesInPlay < 3) && AllPiecesPlaced);
            
        }
        
    }
    
}