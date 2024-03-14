namespace NumberGame;

public class Player
{
    public string? Name { get; init; }
    public int Score { get; set; }

    private static readonly Random Random = new Random();

    public int ChooseNumber(int[] availableNumbers)
    {
        if (availableNumbers == null || availableNumbers.Length == 0)
        {
            throw new ArgumentException("No available numbers to choose from.", nameof(availableNumbers));
        }

        int index = Random.Next(availableNumbers.Length);

        return availableNumbers[index];
    }

    public void UpdateScore(int number)
    {
        Score += number;
    }
}