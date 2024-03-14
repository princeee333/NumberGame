

namespace NumberGame
{
    public class Game
    {
        public Player PlayerOne { get; private set; }
        public Player PlayerTwo { get; private set; }
        private Player CurrentPlayer { get; set; }
        private int[] NumbersAvailable { get; set; }

        private static readonly Random Random = new Random();

        public Game()
        {
            StartGame();
        }

        private void StartGame()
        {
            Console.WriteLine("Please write name of first player: ");
            PlayerOne = new Player { Name = Console.ReadLine()};
            Console.WriteLine("Please write name of  player: ");
            PlayerTwo = new Player { Name = Console.ReadLine()};
            CurrentPlayer = PlayerOne;

            NumbersAvailable = Enumerable.Range(1, 101).ToArray(); 

            Console.WriteLine($"Game started. {CurrentPlayer.Name} turn.");
        }

        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == PlayerOne ? PlayerTwo : PlayerOne;
            Console.WriteLine($"{CurrentPlayer.Name}'s turn.");
        }

        public void CheckWinner()
        {
            bool hasWinner = false;

            if (PlayerOne.Score >= 100)
            {
                DisplayWinner(PlayerOne);
                hasWinner = true;
            }
            else if (PlayerTwo.Score >= 100)
            {
                DisplayWinner(PlayerTwo);
                hasWinner = true;
            }

            if (hasWinner)
            {
                Console.WriteLine("Game over!");
                Environment.Exit(0); 
            }
        }

        private static void DisplayWinner(Player winner)
        {
            Console.WriteLine($"The winner is {winner.Name} with a score of {winner.Score}.");
        }

        public void PlayTurn()
        {
            if (NumbersAvailable.Length == 0)
            {
                Console.WriteLine("No numbers left to choose.");
                return;
            }

            int chosenNumber = CurrentPlayer.ChooseNumber(NumbersAvailable);
            CurrentPlayer.UpdateScore(chosenNumber);
            Console.WriteLine($"{CurrentPlayer.Name} chose {chosenNumber} and now has a score of {CurrentPlayer.Score}.");
            
            NumbersAvailable = NumbersAvailable.Where(n => n != chosenNumber).ToArray();

            SwitchPlayer();
        }

        public void GetNumberChoices()
        {
            Console.WriteLine("Available numbers:");
            foreach (var number in NumbersAvailable)
            {
                Console.WriteLine(number);
            }
        }
    }
}
