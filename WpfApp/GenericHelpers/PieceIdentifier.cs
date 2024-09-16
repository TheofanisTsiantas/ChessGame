namespace WpfApp
{
    /// <summary>
    /// A helper class which is used to fully identify a chess piece
    /// </summary>
    public class PieceIdentifier
    {
        // Type of chess piece (pawn, rock, etc.)
        private PieceType pt;

        // Color of chess piece
        private ChessColor color;

        // Constructor
        public PieceIdentifier(PieceType pt, ChessColor color)
        {
            this.pt = pt;
            this.color = color;
        }

        // Implementation of equality method
        public bool Equals(PieceIdentifier pieceID)
        {
            if (pieceID is PieceIdentifier p)
                return (this.pt == p.pt) && (this.color == p.color);
            return false;
        }
    }
}
