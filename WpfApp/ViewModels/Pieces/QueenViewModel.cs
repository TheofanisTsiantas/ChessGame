using System.Collections.Generic;

namespace WpfApp
{
    /// <summary>
    /// Implementation of queen view model
    /// </summary>
    public class QueenViewModel : BasePieceViewModel
    {
        // Constructor
        public QueenViewModel(ChessColor color) { this.color = color; this.type = PieceType.Queen; }

        /// <summary>
        /// A queen can move in all directions
        /// </summary>
        /// <returns>A list of two dimensional arrays representing all squares where the queen could theoretically move</returns>
        public override List<double[]> ValidSquares()
        {
            return new List<double[]>();
        }
    }
}
