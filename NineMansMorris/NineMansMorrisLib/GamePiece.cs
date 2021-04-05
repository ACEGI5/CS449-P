namespace NineMansMorrisLib
{
    public enum PieceState
    {
        Black,
        White,
        Open,
        Invalid,
        BlackMilled,
        WhiteMilled
    }

    public class GamePiece
    {
        public PieceState PieceState { get; set; }
    }
}