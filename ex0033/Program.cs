internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<(int,int)> candidates = new HashSet<(int, int)>();
        for (int numerator = 11; numerator < 100; numerator++)
        {
            if (numerator % 10 == 0)
            {
                continue;
            }
            for (int denominator = 11; denominator < 100; denominator++)
            {
                if (denominator % 10 == 0)
                {
                    continue;
                }
                List<double> options = new List<double>();
                if (numerator % 10 == denominator % 10)
                {
                    options.Add((double)((int)(numerator/10)) / ((int)(denominator/10)));
                }
                if (numerator % 10 == (int)(denominator / 10))
                {
                    options.Add((double)((int)(numerator / 10)) / (denominator % 10));
                }
                if ((int)(numerator / 10) == denominator % 10)
                {
                    options.Add((double)(numerator % 10) / ((int)(denominator / 10)));
                }
                if ((int)(numerator / 10) == (int)(denominator / 10))
                {
                    options.Add((double)(numerator % 10) / (denominator % 10));
                }

                foreach (double option in options)
                {
                    if (option < 1 && ((double)numerator/(double)denominator) == option)
                    {
                        int[] simplified = _library.Divisors.SimplifyFraction(numerator, denominator);
                        Console.WriteLine($"{numerator}/{denominator} -- {simplified[0]}/{simplified[1]}");
                        candidates.Add((simplified[0], simplified[1]));
                    }
                }
            }
            
        }
        Console.WriteLine("---------------------");
        int resultNumerator = 1;
        int resultDenominator = 1;
        foreach (var candidate in candidates)
        {
            resultNumerator *= candidate.Item1;
            resultDenominator *= candidate.Item2;
        }
        int[] simplifiedResult = _library.Divisors.SimplifyFraction(resultNumerator, resultDenominator);
        Console.WriteLine(simplifiedResult[1]);
        
    }
}