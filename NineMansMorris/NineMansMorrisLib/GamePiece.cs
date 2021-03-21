namespace NineMansMorrisLib {
    
    public enum PieceState {
        
        Black,
        White,
        Open,
        Invalid
        
    }

    public class GamePiece {
        
        public PieceState PieceState { get; set; }
        
    }
    
}