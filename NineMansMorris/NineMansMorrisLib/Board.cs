namespace NineMansMorrisLib
{
    public class Board
    {
        private const int BoardSize = 9;
        private GamePiece[,] _boardArray;
        public Board()
        {
            _boardArray = new GamePiece[BoardSize, BoardSize];
        }
    }
}