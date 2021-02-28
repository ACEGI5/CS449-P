namespace NineMansMorrisLib
{
    public class Player
    {
        public int piecesToPlace = 9;
        public int piecesInPlay = 0;
        public bool canFly = false;
        public bool allPiecesPlaced = false;

        public void threePiecesLeft()
        {
            if (piecesInPlay == 3 && allPiecesPlaced)
            {
                canFly = true;
            }
        }
    }
}