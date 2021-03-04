namespace NineMansMorrisLib
{
    public class GamePiece
    {
        public enum PieceColor
        {
            Black,
            White,
            Open
        }

        public PieceColor Color
        {
            get;
            set;
        }
        public GamePiece()
        {
            Color = PieceColor.Open;
        }
    }
}