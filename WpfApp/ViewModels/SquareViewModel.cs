using System.ComponentModel;

namespace WpfApp
{
    /// <summary>
    /// View model of a square.
    /// 
    /// col: 0 ... 7    
    /// row
    ///  0   |     |
    ///       ----  
    ///  1   |     |
    ///       ----  
    ///  2   |     |
    ///       ----  
    ///  3   |     |
    ///       ----  
    /// ...  |     |
    ///       ----  
    ///  7   |     |
    ///
    /// 
    /// </summary>
    public class SquareViewModel : INotifyPropertyChanged
    {
        // The row where the square is located (top: row = 0, bottom: row = 7) 
        public int row { get; }
        // The column where the square is located (left: column = 0, right: column = 7) 
        public int col { get; }
        // The square color
        private ChessColor color { get; }
        // The interface of a piece which may sit on the square
        public BasePieceViewModel piece { set; get; } = null;

        // Property which indicates if the square is occupied by a selected piece or if 
        // a selected piece could fo to this square
        private bool _isHighlighted = false;
        // Getter/Setter. Triggers modification of the binded property (_isHighlighted) 
        public bool isHighlighted
        {
            set
            {
                _isHighlighted = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(isHighlighted)));

            }
            get { return _isHighlighted; }
        }

        /// <summary>
        /// Constructor of the view mode
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="color"></param>
        public SquareViewModel(int row, int col, ChessColor color)
        {
            this.row = row;
            this.col = col;
            this.color = color;
        }

        // Event which fires when a property has been changed
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
