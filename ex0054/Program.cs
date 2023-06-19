internal class Program
{
    private static void Main(string[] args)
    {
        string pokerFilePath = Path.Combine(Environment.CurrentDirectory, @"0054_poker.txt");
        string[] hands = File.ReadAllLines(pokerFilePath);
        foreach (string handsItem in hands)
        {
            Console.WriteLine(handsItem);
        }
    }
}