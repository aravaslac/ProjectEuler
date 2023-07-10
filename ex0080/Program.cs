using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] squares = FigurateNumbers.GetSquareNumbers(1, 100);

        int sum = 0;
        for (int i = 2; i < 100; i++)
        {
            Console.WriteLine($"i = {i}");
            if (squares.Contains(i))
            {
                continue;
            }
            var root = RootOperations.GetSquareRootDigitByDigit(i, 99);
            sum += root.Item1;
            foreach (var digit in root.Item2)
            {
                sum += digit;
            }
        }
        Console.WriteLine("---------------");
        Console.WriteLine(sum);
    }
}