using System.Numerics;
using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<int,BigInteger> digitSquares = new Dictionary<int,BigInteger>();
        for (int i = 0; i < 10; i++)
        {
            digitSquares[i] = i * i;
        }

        HashSet<BigInteger> loop = new HashSet<BigInteger>
        {
            1, 4, 16, 20, 37, 42, 58, 89, 145
        };

        int counter = 0;
        for (int i = 1; i < 10_000_000; i++)
        {
            BigInteger number = i;
            while (!loop.Contains(number))
            {
                int[] digits = DigitOperations.GetDigitsAsInts(number);

                number = 0;
                foreach (int digit in digits)
                {
                    number += digitSquares[digit];
                }
            }
            if (number != 1)
            {
                counter++;
            }
        }

        Console.WriteLine(counter);
    }
}