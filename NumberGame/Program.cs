namespace NumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Number Game!");

            Game game = new Game(); 

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1 - Play turn");
                Console.WriteLine("2 - Show available numbers");
                Console.WriteLine("3 - Check scores");
                Console.WriteLine("4 - End game");
                Console.Write("Option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        game.PlayTurn();
                        game.CheckWinner(); 
                        break;
                    case "2":
                        game.GetNumberChoices();
                        break;
                    case "3":
                        Console.WriteLine($"Player 1 Score: {game.PlayerOne.Score}");
                        Console.WriteLine($"Player 2 Score: {game.PlayerTwo.Score}");
                        break;
                    case "4":
                        Console.WriteLine("Ending the game...");
                        return; 
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }
    }
}