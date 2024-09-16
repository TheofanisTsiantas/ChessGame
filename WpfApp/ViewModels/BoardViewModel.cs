using System.Collections.Generic;
using System.Windows.Input;

namespace WpfApp
{
    /// <summary>
    /// The view model of the board. It is responsible for managing the state and layout
    /// of the board squares, including knowing where each piece can be. It also holds as
    /// information the currently selected piece (if a piece has beeen selected).
    /// </summary>
    public class BoardViewModel
    {
        // The piece that the current player has selected
        private BasePieceViewModel selectedPiece = null;

        // The view models of all board squares
        public List<SquareViewModel> squares { get; } = new List<SquareViewModel>();

        // The command which is executed when a player selects a piece
        public ICommand OnPieceSelected { get; }

        // Constructor of the board view model
        public BoardViewModel()
        {
            // Make the view models of the squares
            makeSquares();

            // Subscrbe to the event of selecting a piece
            OnPieceSelected = new RelayCommand(_OnPieceSelected);
        }

        /// <summary>
        /// The method which is executed upon a piece selection. It sets the selected 
        /// piece of the board view model class. It finds the square of the selected
        /// piece and highlights it.
        /// </summary>
        /// <param name="o">The selected piece</param>
        private void _OnPieceSelected(object o)
        {
            // Remove any existing highlight of squares
            squares.ForEach(x => x.isHighlighted = false);

            // Get the piece and perform a fallback chedck
            BasePieceViewModel piece = o as BasePieceViewModel;
            if (piece == null)
                return;

            // Assign the piece to the selected piece
            selectedPiece = piece;

            // Find the square of the selected piece and highlight it
            foreach (SquareViewModel sqr in squares)
            {
                if (sqr.piece != null && sqr.piece == piece)
                {
                    sqr.isHighlighted = true;
                    return;
                }
            }
        }

        /// <summary>
        /// The method which makes all the view models of the board squares.
        /// </summary>
        private void makeSquares()
        {
            bool colorWhite = true;

            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 8; row++)
                {
                    squares.Add(new SquareViewModel(row, col, colorWhite == true ? ChessColor.White : ChessColor.Black));
                    // Alternating square color logic
                    colorWhite = colorWhite ? false : true;
                }
                // Alternating square color logic
                colorWhite = colorWhite ? false : true;
            }
        }







    }
}
