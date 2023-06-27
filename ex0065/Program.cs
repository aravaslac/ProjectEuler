using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> continuedFractionBuilder = new List<int> { 2 };
        int j = 1;
        for (int i = 1; i < 100; i++)
        {
            if (i % 3 == 2)
            {
                continuedFractionBuilder.Add(2 * j);
                j++;
                continue;
            }
            continuedFractionBuilder.Add(1);
        }
        int[] continuedFraction = continuedFractionBuilder.ToArray();

        BigInteger[] numerators = _library.ContinuedFractions.GetConvergentNumerators(continuedFraction);
        int[] digits = _library.DigitOperations.GetDigitsAsInts(numerators[99]);

        int sum = 0;
        foreach (int digit in digits)
        {
            sum += digit;
        }
        Console.WriteLine(sum);
    }
}