namespace WpfApp
{
    /// <summary>
    /// A helper class with generic functionalities
    /// </summary>
    public class GenericStaticLibrary
    {
        /// <summary>
        /// A static method which returns the image of a chess piece based on its type and color
        /// </summary>
        /// <param name="type"> Pawn, Rock, etc.</param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string getImagesourceByType(PieceType type, ChessColor color)
        {
            string baseString = "pack://application:,,,/Images/";
            baseString += color == ChessColor.White ? "White" : "Black";
            switch (type)
            {
                case PieceType.Pawn:
                    return baseString + "Pawn.png";
                case PieceType.Rock:
                    return baseString + "Rock.png";
                case PieceType.Knight:
                    return baseString + "Knight.png";
                case PieceType.Bishop:
                    return baseString + "Bishop.png";
                case PieceType.King:
                    return baseString + "King.png";
                case PieceType.Queen:
                    return baseString + "Queen.png";
            }
            return "";
        }

    }
}
