using System.Collections.Generic;

namespace WpfApp
{
    /// <summary>
    /// Game player view model. It holds the name of the player and the color of their pieces.
    /// </summary>
    public class Player
    {
        // Player name
        public string Name { private set; get; }
        // Color of the pieces of the player
        public ChessColor color { private set; get; }

        // The currently available pieces at the players disposal
        public List<BasePieceViewModel> ActivePieces { set; get; } = new List<BasePieceViewModel>();

        // Constructor
        public Player(string Name, ChessColor color)
        {
            this.Name = Name;
            this.color = color;
        }

    }
}
