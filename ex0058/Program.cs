internal class Program
{
    private static void Main(string[] args)
    {
        //Clockwise or anti-clockwise doesn't matter, so this uses Problem 28 as a base
        int[] primes = _library.Sieve.GetPrimes(100_000_000);
        long number = 1;
        int primeCount = 0;
        int totalCount = 1;
        int size = 1;
        double ratio = 100d;
        while (ratio >= 0.095d)
        {
            size += 2;
            for (int side = 0; side < 4; side++)
            {
                number += size - 1;
                if (_library.PrimeFactorization.CheckPrimalityViaFactorization(number,primes))
                {
                    primeCount++;
                }
                totalCount++;
            }
            ratio = (double)primeCount / (double)totalCount;
            Console.WriteLine($"size: {size} // primes: {primeCount} // total: {totalCount} // {ratio}");
        }
    }
}