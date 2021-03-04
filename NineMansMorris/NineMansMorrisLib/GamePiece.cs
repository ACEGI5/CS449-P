namespace NineMansMorrisLib
{
    public class GamePiece
    {
        public enum PieceColor
        {
            black,
            white,
            open
        }
        private PieceColor color;
        public GamePiece()
        {
            color = PieceColor.open;
        }
        
        public PieceColor getColor()
        {
            return color;
        }
        public void setColor(PieceColor newColor)
        {
            color = newColor;
        }
    }
}