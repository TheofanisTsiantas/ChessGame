using System.Collections.Generic;

namespace WpfApp
{
    /// <summary>
    /// Implementation of pawn view model
    /// </summary>
    public class PawnViewModel : BasePieceViewModel
    {
        // Constructor
        public PawnViewModel(ChessColor color) { this.color = color; this.type = PieceType.Pawn; }

        /// <summary>
        /// A pawn can move only one square forward unless it is in its initiali square, where it can also move two squares forward.
        /// </summary>
        /// <returns>A list of two dimensional arrays representing all squares where the pawn could theoretically move</returns>
        public override List<double[]> ValidSquares()
        {
            return new List<double[]>();
        }
    }
}
