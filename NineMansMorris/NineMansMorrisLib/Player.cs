namespace NineMansMorrisLib
{
    public class Player
    {
        public int PiecesToPlace = 9;
        public int PiecesInPlay = 0;
        public bool AllPiecesPlaced = false;
        public char PlayerColor;

        public void SetPlayerColor(char color)
        {
            PlayerColor = color;
        }

        // Checks if a player has only three pieces left.
        // If so, player may begin flying pieces.
        // Output: bool representing if player can fly.
        public bool PlayerCanFly()
        {
            return (PiecesInPlay == 3 && AllPiecesPlaced);
        }

        // Checks if player has placed all pieces.
        // If so, player must start moving placed pieces on board.
        // Output: returns no value.
        public void PiecesPlaced()
        {
            if (PiecesToPlace == 0)
            {
                AllPiecesPlaced = true;
            }
        }
    }
}