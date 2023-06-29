using _library;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = Sieve.GetPrimes(10_000_000);
        int[] composites = Sieve.GetComposites(10_000_000);
        int count = 0;
        foreach (int i in primes)
        {
            HashSet<int> uniqueFactors = _library.PrimeFactorization.GetUniqueFactors(i, primes);

            int radical = 1;
            foreach (int factor in uniqueFactors)
            {
                radical *= factor;
            }
            if (radical == i)
            {
                count++;
            }
        }
        Console.WriteLine($"Composites: {composites.Length}. Radicals: {count}");
    }
}