using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        var primes = Sieve.GetPrimes(31427);
        var factors = PrimeFactorization.Factorize(78431, primes);
        foreach (var factor in factors)
        {
            Console.WriteLine(factor.ToString());
        }
    }
}