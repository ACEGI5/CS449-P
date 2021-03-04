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
        public PieceColor color
        {
            get;
            set;
        }
        public GamePiece()
        {
            color = PieceColor.open;
        }
    }
}