using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        //Further reading: Pell's equation

        HashSet<int> squares = _library.FigurateNumbers.GetSquareNumbers(1, 1000).ToHashSet();

        BigInteger maxX = 0;
        int maxXGenerator = 0;
        for (int i = 1; i <= 1000; i++)
        {
            if (squares.Contains(i))
            {
                continue;
            }

            List<int> period = _library.ContinuedFractions.GetContinuedFraction(i).ToList();
            int a0 = period[0];
            period.RemoveAt(0);
            int periodSize = period.Count;

            bool solutionNotFound = true;
            int range = 0;
            while (solutionNotFound)
            {
                range++;
                List<int> continuedFractionBuilder = new List<int> { a0 };
                for (int j = 0; j < range * 100; j++)
                {
                    continuedFractionBuilder.Add(period[j % periodSize]);
                }
                int[] continuedFraction = continuedFractionBuilder.ToArray();
                BigInteger[] numerators = _library.ContinuedFractions.GetConvergentNumerators(continuedFraction);
                BigInteger[] denominators = _library.ContinuedFractions.GetConvergentDenominators(continuedFraction);

                for (int k = 0; k <= range * 100; k++)
                {
                    BigInteger x = numerators[k];
                    BigInteger y = denominators[k];
                    if (x * x - i * y * y == 1)
                    {
                        if (x > maxX)
                        {
                            maxX = x;
                            maxXGenerator = i;
                        }
                        Console.WriteLine($"D = {i}; x = {x}; y = {y}");
                        Console.WriteLine($"{x}^2 - {i} * {y}^2 = 1");
                        Console.WriteLine("----------------------");
                        solutionNotFound = false;
                        break;
                    }
                }
            }
        }
        Console.WriteLine("------------------------");
        Console.WriteLine($"Max value of x = {maxX}");
        Console.WriteLine($"Occurs ad D = {maxXGenerator}");
    }
}