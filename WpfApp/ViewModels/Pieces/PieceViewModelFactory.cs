namespace WpfApp
{
    /// <summary>
    /// A piece view model factory for generating the various piece view models
    /// </summary>
    public class PieceViewModelFactory
    {
        public static BasePieceViewModel MakePieceViewModel(PieceType piece, ChessColor color)
        {
            switch (piece)
            {
                case PieceType.Pawn:
                    return new PawnViewModel(color);
                case PieceType.Rock:
                    return new RockViewModel(color);
                case PieceType.Knight:
                    return new KnightViewModel(color);
                case PieceType.Bishop:
                    return new BishopViewModel(color);
                case PieceType.King:
                    return new KingViewModel(color);
                case PieceType.Queen:
                    return new QueenViewModel(color);
            }

            return null;
        }
    }
}
