using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] pentagonalNumbers = FigurateNumbers.GetPentagonalNumbers(1000);
        foreach (int number in pentagonalNumbers)
        {
            Console.WriteLine(number);
        }
        
    }
}