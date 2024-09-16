using System.Collections.Generic;
using System.Linq;

namespace WpfApp
{
    /// <summary>
    /// The high level class which orchistraytes the game flow: Managing turns, players and overall state.
    /// </summary>
    public class Game
    {
        // The game players
        private List<Player> players = new List<Player>();

        // The view model of the board
        public BoardViewModel board { private set; get; }

        /// <summary>
        /// Constructor of the game class
        /// </summary>
        /// <param name="whitePlayerName"></param>
        /// <param name="blackPlayerName"></param>
        public Game(string whitePlayerName, string blackPlayerName)
        {
            // Initialize layers
            players.Add(new Player(whitePlayerName, ChessColor.White));
            players.Add(new Player(blackPlayerName, ChessColor.Black));

            // Distribute the pieces to the players
            makePieces();

            // Make the board view model (creation of squares)
            board = new BoardViewModel();

            // Assign each piece view model to the correct square view model for the beginning of the game
            PieceSquareViewModelConnection();
        }

        /// <summary>
        /// Creates the pieces and assigns them to the corresponding player
        /// </summary>
        private void makePieces()
        {
            foreach (Player player in players)
            {
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Pawn, player.color)); // Pawn 1
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Pawn, player.color)); // Pawn 2
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Pawn, player.color)); // Pawn 3
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Pawn, player.color)); // Pawn 4
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Pawn, player.color)); // Pawn 5
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Pawn, player.color)); // Pawn 6
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Pawn, player.color)); // Pawn 7
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Pawn, player.color)); // Pawn 8
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Rock, player.color)); // Rock
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Rock, player.color)); // Rock
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Knight, player.color)); // Knight
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Knight, player.color)); // Knight
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Bishop, player.color)); // Bishop
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Bishop, player.color)); // Bishop
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.Queen, player.color)); // Queen
                player.ActivePieces.Add(PieceViewModelFactory.MakePieceViewModel(PieceType.King, player.color)); // King
            }
        }

        /// <summary>
        /// Method to return the view models of all pieces of the board. It is needed for 
        /// assigning the piece view models to the piece views. 
        /// </summary>
        public List<BasePieceViewModel> getAllPieces()
        {
            List<BasePieceViewModel> allPieces = new List<BasePieceViewModel>();
            allPieces.AddRange(players[0].ActivePieces);
            allPieces.AddRange(players[1].ActivePieces);
            return allPieces;
        }

        /// <summary>
        /// Connection of square view model to piece view model (a square can hold a piece)
        /// </summary>
        private void PieceSquareViewModelConnection()
        {
            List<BasePieceViewModel> piecesToDistribute = getAllPieces();

            // White Pawns
            List<BasePieceViewModel> whitePawns = piecesToDistribute.Where(x => x.type == PieceType.Pawn && x.color == ChessColor.White).ToList();
            for (int i = 0; i < whitePawns.Count; i++)
                board.squares.Find(x => x.row == 6 && x.col == i).piece = whitePawns[i];

            // White Rocks
            List<BasePieceViewModel> whiteRocks = piecesToDistribute.Where(x => x.type == PieceType.Rock && x.color == ChessColor.White).ToList();
            board.squares.Find(x => x.row == 7 && x.col == 0).piece = whiteRocks[0];
            board.squares.Find(x => x.row == 7 && x.col == 7).piece = whiteRocks[1];

            // White Knights
            List<BasePieceViewModel> whiteKnights = piecesToDistribute.Where(x => x.type == PieceType.Knight && x.color == ChessColor.White).ToList();
            board.squares.Find(x => x.row == 7 && x.col == 1).piece = whiteKnights[0];
            board.squares.Find(x => x.row == 7 && x.col == 6).piece = whiteKnights[1];

            // White Bishops
            List<BasePieceViewModel> whiteBishops = piecesToDistribute.Where(x => x.type == PieceType.Bishop && x.color == ChessColor.White).ToList();
            board.squares.Find(x => x.row == 7 && x.col == 2).piece = whiteBishops[0];
            board.squares.Find(x => x.row == 7 && x.col == 5).piece = whiteBishops[1];

            // White Kinkg
            BasePieceViewModel whiteKing = piecesToDistribute.Find(x => x.type == PieceType.King && x.color == ChessColor.White);
            board.squares.Find(x => x.row == 7 && x.col == 4).piece = whiteKing;

            // White Queen
            BasePieceViewModel whiteQueen = piecesToDistribute.Find(x => x.type == PieceType.Queen && x.color == ChessColor.White);
            board.squares.Find(x => x.row == 7 && x.col == 3).piece = whiteQueen;

            // Black Pawns
            List<BasePieceViewModel> blackPawns = piecesToDistribute.Where(x => x.type == PieceType.Pawn && x.color == ChessColor.Black).ToList();
            for (int i = 0; i < blackPawns.Count; i++)
                board.squares.Find(x => x.row == 1 && x.col == i).piece = blackPawns[i];

            // Black Rocks
            List<BasePieceViewModel> blackRocks = piecesToDistribute.Where(x => x.type == PieceType.Rock && x.color == ChessColor.Black).ToList();
            board.squares.Find(x => x.row == 0 && x.col == 0).piece = blackRocks[0];
            board.squares.Find(x => x.row == 0 && x.col == 7).piece = blackRocks[1];

            // Black Knights
            List<BasePieceViewModel> blackKnights = piecesToDistribute.Where(x => x.type == PieceType.Knight && x.color == ChessColor.Black).ToList();
            board.squares.Find(x => x.row == 0 && x.col == 1).piece = blackKnights[0];
            board.squares.Find(x => x.row == 0 && x.col == 6).piece = blackKnights[1];

            // Black Bishops
            List<BasePieceViewModel> blackBishops = piecesToDistribute.Where(x => x.type == PieceType.Bishop && x.color == ChessColor.Black).ToList();
            board.squares.Find(x => x.row == 0 && x.col == 2).piece = blackBishops[0];
            board.squares.Find(x => x.row == 0 && x.col == 5).piece = blackBishops[1];

            // Black Kinkg
            BasePieceViewModel blackKing = piecesToDistribute.Find(x => x.type == PieceType.King && x.color == ChessColor.Black);
            board.squares.Find(x => x.row == 0 && x.col == 4).piece = blackKing;

            // Black Queen
            BasePieceViewModel blackQueen = piecesToDistribute.Find(x => x.type == PieceType.Queen && x.color == ChessColor.Black);
            board.squares.Find(x => x.row == 0 && x.col == 3).piece = blackQueen;
        }
    }
}
