internal class Program
{
    private static void Main(string[] args)
    {
        int[] nonPrimeDigits = new int[] {0,2,4,5,6,8};
        int[] primes = _library.Sieve.GetPrimes(((int)Math.Sqrt(987654321)) + 1);
        for (int i = 987654321; i > 1; i--)
        {
            if (nonPrimeDigits.Contains(i % 10) || !_library.DigitOperations.CheckIsPandigital(i))
            {
                continue;
            }
        
            Console.WriteLine(i);

            if (_library.PrimeFactorization.CheckPrimalityViaFactorization(i, primes))
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine(i);
                Console.ReadLine();
                Environment.Exit(0);
            }

        }
    }
}