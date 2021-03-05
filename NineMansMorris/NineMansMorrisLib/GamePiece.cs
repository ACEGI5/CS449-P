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

        private PieceColor Color {get; set;}
        public GamePiece()
        {
            Color = PieceColor.Open;
        }
    }
}