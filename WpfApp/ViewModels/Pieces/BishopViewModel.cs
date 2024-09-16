using System.Collections.Generic;

namespace WpfApp
{
    /// <summary>
    /// Implementation of bioshop view model
    /// </summary>
    public class BishopViewModel : BasePieceViewModel
    {
        // Constructor
        public BishopViewModel(ChessColor color) { this.color = color; this.type = PieceType.Bishop; }

        /// <summary>
        /// A bishop can move diagonally
        /// </summary>
        /// <returns>A list of two dimensional arrays representing all squares where the bishop could theoretically move</returns>
        public override List<double[]> ValidSquares()
        {
            return new List<double[]>();
        }
    }
}
