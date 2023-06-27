internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<int> PerfectSquares = _library.FigurateNumbers.GetSquareNumbers(1, 10000).ToHashSet();
        int oddPeriods = 0;
        for (int i = 1; i <= 10000; i++)
        {
            if (PerfectSquares.Contains(i))
            {
                continue;
            }

            //form: numerator/(sqrt(i) - b)
            int a0 = (int) Math.Sqrt(i);
            int b = a0;
            int numerator = 1;
            List<int> period = new List<int>();
            List<int> bValues = new List<int>();
            List<int> numeratorValues = new List<int>();
            bool periodBuilder = true;
            int size = 0;
            while (periodBuilder)
            {
                int aN = (int)(numerator / (Math.Sqrt(i) - b));
                numerator = _library.RootOperations.GetRationalizedDenominator(i, b)/numerator;
                b = numerator * aN - b;

                period.Add(aN);
                bValues.Add(b);
                numeratorValues.Add(numerator);
                size = period.Count;

                if (size % 2 == 0
                        && _library.DigitOperations.CheckIsNPeriodic(period, size / 2)
                        && _library.DigitOperations.CheckIsNPeriodic(bValues, size / 2)
                        && _library.DigitOperations.CheckIsNPeriodic(numeratorValues, size / 2)
                   )
                {
                    periodBuilder = false;
                }
            }

            size /= 2;
            if (size % 2 != 0)
            {
                oddPeriods++;
            }

            Console.Write($"sqrt({i}) = [{a0}; (");
            for (int j = 0; j < size - 1; j++)
            {
                Console.Write($"{period[j]},");
            }
            Console.WriteLine($"{period[size - 1]})]");
        }
        Console.WriteLine("-----------------------");
        Console.WriteLine(oddPeriods);
    }
}