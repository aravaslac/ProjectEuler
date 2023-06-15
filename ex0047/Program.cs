internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = _library.Sieve.GetPrimes(1000);

        int successes = 0;
        int firstNumber = 0;
        bool foundThem = false;
        for (int i = 1; i < 1_000_001; i++)
        {
            HashSet<int> uniqueFactors = _library.PrimeFactorization.GetUniqueFactors(i, primes);
            if (uniqueFactors.Count > 3)
            {
                successes++;
            }
            else
            {
                successes = 0;
            }

            if (successes == 4)
            {
                foundThem = true;
                firstNumber = i - 3;
                break;
            }
        }

        if (foundThem)
        {
            Console.WriteLine(firstNumber);
        }
        else
        {
            Console.WriteLine("Deu ruim");
        }
    }
}