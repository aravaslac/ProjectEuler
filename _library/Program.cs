using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> numbers = new List<int>
        {
            12, 60, 100
        };
        Console.WriteLine(Divisors.GetGreatestCommonDivisor(numbers));
        Console.ReadLine();
    }
}