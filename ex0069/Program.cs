internal class Program
{
    private static void Main(string[] args)
    {
        // from https://en.wikipedia.org/wiki/Euler%27s_totient_function
        // n/phi(n) = rad(n)/phi(rad(n)), where rad(n) is the product of all distinct prime divisors of n

        int[] primes = _library.Sieve.GetPrimes(1_000_000);
        int[] composites = _library.Sieve.GetComposites(1_000_000);

        Console.WriteLine(primes.Length);

        int n = 2;
        double maxValue = 2;
        foreach (int i in composites)
        {
            HashSet<int> uniqueFactors = _library.PrimeFactorization.GetUniqueFactors(i, primes);

            int radical = 1;
            foreach (int factor in uniqueFactors)
            {
                radical *= factor;
            }
            if (i != radical)
            {
                continue;
            }

            int phi = 1;
            foreach (int factor in uniqueFactors)
            {
                phi *= factor - 1;
            }

            double value = (double)i / phi;
            if (value > maxValue)
            {
                Console.WriteLine($"{i} {value}");
                maxValue = value;
                n = i;
            }
        }
        Console.WriteLine("-----------------");
        Console.WriteLine($"{n} {maxValue}");
    }
}