using System.Collections.Generic;

namespace WpfApp
{
    /// <summary>
    /// Implementation of king view model
    /// </summary>
    public class KingViewModel : BasePieceViewModel
    {
        // Constructor
        public KingViewModel(ChessColor color) { this.color = color; this.type = PieceType.King; }

        /// <summary>
        /// A king can move in all directions but only by one square
        /// </summary>
        /// <returns>A list of two dimensional arrays representing all squares where the knight could theoretically move</returns>
        public override List<double[]> ValidSquares()
        {
            return new List<double[]>();
        }
    }
}
