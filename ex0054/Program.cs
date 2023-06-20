using ex0054;

internal class Program
{
    private static void Main(string[] args)
    {
        string filePath = Path.Combine(Environment.CurrentDirectory, @"0054_poker.txt");
        string[] hands = File.ReadAllLines(filePath);
        int player1Victories = 0;
        foreach (string hand in hands)
        {
            string[] cards = hand.Split(' ');
            List<string> player1 = new List<string>();
            List<string> player2 = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                player1.Add(cards[i]);
                player2.Add(cards[i+5]);
            }
            if (HandEvaluator.GetVictor(player1, player2) == 1)
            {
                player1Victories++;
            }
        }
        Console.WriteLine(player1Victories);
    }
}