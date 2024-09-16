using System.Collections.Generic;

namespace WpfApp
{
    /// <summary>
    /// Implementation of knight view model
    /// </summary>
    public class KnightViewModel : BasePieceViewModel
    {
        // Constructor
        public KnightViewModel(ChessColor color) { this.color = color; this.type = PieceType.Knight; }

        /// <summary>
        /// A knight can move in L-shape
        /// </summary>
        /// <returns>A list of two dimensional arrays representing all squares where the knight could theoretically move</returns>
        public override List<double[]> ValidSquares()
        {
            return new List<double[]>();
        }
    }
}
