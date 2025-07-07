using Board;
using System.ComponentModel.DataAnnotations;

namespace Game
{
    public class ChessGame
    {
        public enum Status { Done, Victory, Draw, Progressing };
        private Board.Board myBoard = new();
        public Status gameStatus = Status.Progressing;
        Piece.PieceColor activePlayer = Piece.PieceColor.None;

        public Status StartGame()
        {
            myBoard.DisplayBoard();
            return gameStatus;
        }

        public Status TakeNextTurn()
        {
            DisplayNextTurnMessage();

            return gameStatus;
        }

        private void DisplayNextTurnMessage()
        {
            bool validSelection = true;
            if (activePlayer == Piece.PieceColor.None)
            {
                activePlayer = Piece.PieceColor.White;
            }
            else
            {
                activePlayer = activePlayer == Piece.PieceColor.White ? Piece.PieceColor.Black : Piece.PieceColor.White;
                Console.Clear();
                myBoard.DisplayBoard();
            }
            do
            {
                Console.WriteLine(activePlayer.ToString() + "'s turn.");
                Console.WriteLine("Enter move with to and from cordinates (e.g. e7 e5):");
                string input = Console.ReadLine();
                if(input.ToLower() == "quit")
                {
                    gameStatus = Status.Done;
                    Console.WriteLine(activePlayer.ToString() + " resigns. Game over.");
                    return;
                }
                string[] cords = input.Split(' ');
                if(validateSquareSelection(cords) &&
                    validateStartingColor(cords[0]) &&
                    validateEndpoint(cords[1])
                  )
                {
                    validSelection = true;
                }
                else
                    validSelection = false;
            } while(validSelection == false);
        }

        private bool validateSquareSelection(string[] Squares)
        {
            if(Squares.Length != 2)
            {
                Console.Clear();
                myBoard.DisplayBoard();
                Console.WriteLine("Invalid input. Please enter two squares separated by a space.");
                return false;
            }
            foreach (string s in Squares)
            {
                if (s.Length != 2 || !char.IsLetter(s[0]) || !char.IsDigit(s[1]))
                {
                    Console.WriteLine($"Invalid square: {s}. Please use format like 'e2' or 'a7'.");
                    return false;
                }
                char column = char.ToLower(s[0]);
                char row = s[1];
                if (column < 'a' || column > 'h' || row < '1' || row > '8')
                {
                    Console.WriteLine($"Invalid square: {s}. Please use columns a-h and rows 1-8.");
                    return false;
                }
            }
            return true;
        }

        private bool validateStartingColor(string StartingSquare)
        {
            return true;
        }

        private bool validateEndpoint(string EndingSquare)
        {
            return true;
        }

        private bool validate;
        // check for end game conditions (checkmate, stalemate, resign, draw)

        //change turns
    }
}
