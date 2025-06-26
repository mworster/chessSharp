using Piece;

namespace Board
{
    // A board is a multi-dimensional array
    //
    //  0,0   1,0   2,0   3,0   ...
    //  0,1   1,1   2,1   3,1
    //  0,2   1,2   2,2   3,2
    //  ...

    public class Board
    {
        public ChessPiece[,] Squares { get; } = new ChessPiece[8, 8];

        public Board()
        {
            initializeBoard();
        }

        public void initializeBoard()
        {
            for (int i = 0; i < Squares.GetLength(0); i++)
            {
                Squares[i, 1] = new ChessPiece(PieceColor.Black, PieceType.Pawn);  // The 2nd row is white pawns
                Squares[i, 6] = new ChessPiece(PieceColor.White, PieceType.Pawn);  // The 7th row is black pawns
            }

            setBackRank(0, PieceColor.Black);
            setBackRank(7, PieceColor.White);

            for(int row = 2; row < Squares.GetLength(0)-2; row++)
            {
                for(int col = 0; col < Squares.GetLength(1); col++)
                {
                    Squares[col, row] = new ChessPiece(PieceColor.None, PieceType.None);
                }
            }
        }

        public void setBackRank(int row, PieceColor color)
        {
            PieceType[] order = { PieceType.Rook, PieceType.Knight, PieceType.Bishop, PieceType.Queen, 
                                  PieceType.King, PieceType.Bishop, PieceType.Knight, PieceType.Rook};

            for (int i = 0; i < order.Length; i++)
            {
                Squares[i, row] = new ChessPiece(color, order[i]);
            }
            
        }

        public void DisplayBoard()
        {
            int rows = Squares.GetLength(1);
            int cols = Squares.GetLength(0);
            string[] colLabels = { "a", "b", "c", "d", "e", "f", "g", "h" };
            Console.Clear();
            // Top column labels
            Console.Write("    ");
            for (int col = 0; col < cols; col++)
                Console.Write($"  {colLabels[col]}   ");
            Console.WriteLine();

            // Top border
            Console.Write("   +");
            for (int col = 0; col < cols; col++)
                Console.Write("-----+");
            Console.WriteLine();

            for (int row = 0; row < rows; row++)
            {
                int displayRow = 8 - row; // Chess boards are labeled 8 (top) to 1 (bottom)
                // Row with pieces
                Console.Write($" {displayRow} |");
                for (int col = 0; col < cols; col++)
                {
                    ChessPiece piece = Squares[col, row];
                    string cell;
                    if (piece.Type == PieceType.None)
                    {
                        cell = "    ";
                    }
                    else
                    {
                        string colorLetter = piece.Color.ToString().Length > 0 ? piece.Color.ToString().Substring(0, 1).ToLower() : " ";
                        string typeLetter;
                        if (piece.Type == PieceType.King)
                            typeLetter = piece.Type.ToString().Length > 0 ? piece.Type.ToString().Substring(0, 2).ToUpper() : " ";
                        else
                            typeLetter = piece.Type.ToString().Length > 0 ? piece.Type.ToString().Substring(0, 1).ToUpper() : " ";
                        cell = $"{colorLetter}{typeLetter}".PadRight(4);
                    }
                    Console.Write($" {cell}|");
                }
                Console.WriteLine($" {displayRow}");

                // Row border
                Console.Write("   +");
                for (int col = 0; col < cols; col++)
                    Console.Write("-----+");
                Console.WriteLine();
            }

            // Bottom column labels
            Console.Write("    ");
            for (int col = 0; col < cols; col++)
                Console.Write($"  {colLabels[col]}   ");
            Console.WriteLine();
        }
    }
}
