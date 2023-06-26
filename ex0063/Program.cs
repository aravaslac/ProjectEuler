using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<BigInteger> validNumbers = new HashSet<BigInteger> { 1, 2, 3, 4, 5, 6, 7, 8, 9};
        for (int i = 2; i < 10;  i++)
        {
            BigInteger b = i;
            for (int exponent = 2; exponent < 100; exponent++)
            {
                b *= i;
                Console.WriteLine($"{i}^{exponent} = {b}");
                if (_library.DigitOperations.GetNumberOfDigits(b) == exponent)
                {
                    validNumbers.Add(b);
                }
            }
        }
        Console.WriteLine("---------------------");
        Console.WriteLine(validNumbers.Count);
    }
}