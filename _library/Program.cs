using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = Sieve.GetPrimes(100);
        HashSet<int> ints = PrimeFactorization.GetUniqueFactors(646, primes);
        foreach (int i in ints)
        {
            Console.WriteLine(i);
        }
    }
}