using System.Collections.Generic;

namespace WpfApp
{
    /// <summary>
    /// Implementation of rock view model
    /// </summary>
    public class RockViewModel : BasePieceViewModel
    {
        // Constructor
        public RockViewModel(ChessColor color) { this.color = color; this.type = PieceType.Rock; }

        /// <summary>
        /// A rock can move in horizontally and vertically to its location
        /// </summary>
        /// <returns>A list of two dimensional arrays representing all squares where the rock could theoretically move</returns>
        public override List<double[]> ValidSquares()
        {
            return new List<double[]>();
        }
    }
}
