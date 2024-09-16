using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// The view of the chess board. It also contains the view of the squares and of the 
    /// pieces. It only initializes the views.
    /// </summary>
    public partial class BoardView : Window
    {
        public BoardView()
        {
            InitializeComponent();

            // Create views
            MakeViewOfSquares();
            MakeViewOfPieces();
        }

        /// <summary>
        /// The view of the squares of the board. It is utilizes a rectangle element.
        /// </summary>
        private void MakeViewOfSquares()
        {
            bool colorWhite = true;
            SolidColorBrush lightBrush = new SolidColorBrush(Colors.YellowGreen);
            SolidColorBrush darkBrush = new SolidColorBrush(Colors.DarkGreen);
            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 8; row++)
                {
                    // Create a rectangular view to show on the board
                    Rectangle rec = new Rectangle();
                    rec.Fill = colorWhite ? lightBrush : darkBrush;
                    rec.HorizontalAlignment = HorizontalAlignment.Stretch;
                    rec.VerticalAlignment = VerticalAlignment.Stretch;
                    rec.Visibility = Visibility.Visible;
                    rec.Tag = col.ToString() + row.ToString();
                    Grid.SetRow(rec, row);
                    Grid.SetColumn(rec, col);
                    Grid.SetColumnSpan(rec, 1);
                    Grid.SetRowSpan(rec, 1);

                    // Add the view to the grid
                    BoardGrid.Children.Add(rec);

                    // Alternating square color logic
                    colorWhite = colorWhite ? false : true;
                }
                colorWhite = colorWhite ? false : true;
            }
        }

        /// <summary>
        /// The view of the pieces of the board. It is utilizes a button with the corresponding piece image.
        /// </summary>
        private void MakeViewOfPieces()
        {
            // White Pawns
            for (int col = 0; col < 8; col++)
                MakeViewOfPiece(col, 6, PieceType.Pawn, ChessColor.White);

            // White Rocks
            MakeViewOfPiece(0, 7, PieceType.Rock, ChessColor.White);
            MakeViewOfPiece(7, 7, PieceType.Rock, ChessColor.White);

            // White Knights
            MakeViewOfPiece(1, 7, PieceType.Knight, ChessColor.White);
            MakeViewOfPiece(6, 7, PieceType.Knight, ChessColor.White);

            // White Bishops
            MakeViewOfPiece(2, 7, PieceType.Bishop, ChessColor.White);
            MakeViewOfPiece(5, 7, PieceType.Bishop, ChessColor.White);

            // White King/Queen
            MakeViewOfPiece(3, 7, PieceType.Queen, ChessColor.White);
            MakeViewOfPiece(4, 7, PieceType.King, ChessColor.White);

            // Black Pawns
            for (int col = 0; col < 8; col++)
                MakeViewOfPiece(col, 1, PieceType.Pawn, ChessColor.Black);

            // Black Rocks
            MakeViewOfPiece(0, 0, PieceType.Rock, ChessColor.Black);
            MakeViewOfPiece(7, 0, PieceType.Rock, ChessColor.Black);

            // Black Knights
            MakeViewOfPiece(1, 0, PieceType.Knight, ChessColor.Black);
            MakeViewOfPiece(6, 0, PieceType.Knight, ChessColor.Black);

            // Black Bishops
            MakeViewOfPiece(2, 0, PieceType.Bishop, ChessColor.Black);
            MakeViewOfPiece(5, 0, PieceType.Bishop, ChessColor.Black);

            // Black King/Queen
            MakeViewOfPiece(3, 0, PieceType.Queen, ChessColor.Black);
            MakeViewOfPiece(4, 0, PieceType.King, ChessColor.Black);
        }

        /// <summary>
        /// Method to make the view of each individual button.
        /// </summary>
        private void MakeViewOfPiece(int col, int row, PieceType type, ChessColor color)
        {
            Button pieceBtn = new Button();
            pieceBtn.HorizontalAlignment = HorizontalAlignment.Stretch;
            pieceBtn.VerticalAlignment = VerticalAlignment.Stretch;
            Grid.SetRow(pieceBtn, row);
            Grid.SetColumn(pieceBtn, col);
            Grid.SetColumnSpan(pieceBtn, 1);
            Grid.SetRowSpan(pieceBtn, 1);
            pieceBtn.Tag = new PieceIdentifier(type, color);

            // Piece image 
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(GenericStaticLibrary.getImagesourceByType(type, color)));

            // Set the Image as the content of the button
            pieceBtn.Content = img;

            // Set the background of the piece icon to transparent
            pieceBtn.Background = new SolidColorBrush(Colors.Transparent);

            // Add the button to the grid
            BoardGrid.Children.Add(pieceBtn);
        }

    }
}
