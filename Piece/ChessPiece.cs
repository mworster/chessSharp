namespace Piece
{
    public enum PieceType { None, Pawn, Rook, Knight, Bishop, Queen, King}
    public enum PieceColor { None, Black, White };
    public class ChessPiece
    {
        public PieceType Type { get; set; }
        public PieceColor Color { get; set; }

        public ChessPiece() 
        { 
            Type = PieceType.None;
            Color = PieceColor.None;
        }

        public ChessPiece(PieceColor color, PieceType type)
        {
            Type = type;
            Color = color;
        }

    }
}
