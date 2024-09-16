using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// The application starter class. In creates a new game with two players, initializes all views and 
    /// makes the view bindings to all the view models.
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Initialize the game and all the view models
            Game chessGame = new Game("Fanis", "Nikos");

            // Make the views
            BoardView gameWindow = new BoardView();
            gameWindow.DataContext = chessGame.board;

            // Make the view bindings
            // Square view <--> square view model
            foreach (UIElement element in gameWindow.BoardGrid.Children)
            {
                // Get the element as rectangle
                Rectangle rectangle = element as Rectangle;
                if (rectangle == null)
                    continue;

                foreach (SquareViewModel squareViewModel in chessGame.board.squares)
                {
                    if (squareViewModel.col.ToString() + squareViewModel.row.ToString() == (string)rectangle.Tag)
                    {
                        // Binding 
                        rectangle.DataContext = squareViewModel;

                        // Create a binding for the opacity property
                        Binding opacityBinding = new Binding("isHighlighted")
                        {
                            Converter = new BooleanToOpacityConverter()
                        };
                        rectangle.SetBinding(Rectangle.OpacityProperty, opacityBinding);
                    }
                }
            }

            // Piece view <--> piece view model
            List<BasePieceViewModel> piecesForBinding = chessGame.getAllPieces();
            foreach (UIElement element in gameWindow.BoardGrid.Children)
            {
                // Get the element as button
                Button button = element as Button;
                if (button == null)
                    continue;

                foreach (BasePieceViewModel piece in piecesForBinding)
                {
                    if (((PieceIdentifier)button.Tag).Equals(new PieceIdentifier(piece.type, piece.color)))
                    {
                        // Binding 
                        button.DataContext = piece;
                        // Click event event 
                        button.Command = chessGame.board.OnPieceSelected;
                        button.CommandParameter = piece;

                        piecesForBinding.Remove(piece);
                        break;
                    }
                }
            }

        }
    }

    /// <summary>
    /// A converter of a boolean property to the opacity of a rectangle (used in binding)
    /// </summary>
    public class BooleanToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool isHighlighted)
            {
                return isHighlighted ? 1.0 : 0.5;  // Fully opaque if true, semi-transparent if false
            }
            return 1.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
