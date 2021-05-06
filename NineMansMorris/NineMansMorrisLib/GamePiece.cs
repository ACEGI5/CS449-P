namespace NineMansMorrisLib
{
    public enum PieceState
    {
        Black,
        White,
        Open,
        Invalid
    }

    public enum MillState
    {
        NotMilled,
        Milled
    }

    public class GamePiece
    {
        public PieceState PieceState { get; set; }
        public MillState MillState { get; set; }
    }
}