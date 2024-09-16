using System.Collections.Generic;

namespace WpfApp
{
    /// <summary>
    /// Base class of a chess piece view model
    /// </summary>
    public abstract class BasePieceViewModel
    {
        // Piece color
        public ChessColor color { get; protected set; }
        // Piece type (pawn, rock, etc.)
        public PieceType type { get; protected set; }

        /// <summary>
        /// Method which computes the squares where a piece can move.
        /// </summary>
        /// <returns>A list of two dimensional arrays representing the coordinates where the piece can move.</returns>
        public abstract List<double[]> ValidSquares();

    }
}
