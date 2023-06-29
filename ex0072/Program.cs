using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        // https://en.wikipedia.org/wiki/Farey_sequence

        Console.WriteLine(Totient.GetTotientSum(1_000_000) - 1);
    }
}