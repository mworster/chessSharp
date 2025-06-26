using Game;
public class Program
{
    static void Main()
    {
        Console.WriteLine("Starting SharpChess...");
        // Pause for 3 seconds
        string input;
        do
        {
            ChessGame localGame = new ChessGame();
            ChessGame.Status GameStatus = localGame.StartGame();
            while (GameStatus == ChessGame.Status.Progressing)
            {
                GameStatus = localGame.TakeNextTurn();
            }
            Console.WriteLine("Play again? (y/n)");
            input = Console.ReadLine().ToLower();
        } while (input == "yes" || input == "y");
    }
}