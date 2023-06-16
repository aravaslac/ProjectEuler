internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = _library.Sieve.GetPrimes(1_000_000);
        int numberOfPrimesInSieve = primes.Length;
        int maxNumberOfPrimes = 21;
        int specialPrime = 953;
        for (int i = Array.IndexOf(primes,953); i < numberOfPrimesInSieve; i++)
        {
            for (int startingPrimeIndex = 0;  startingPrimeIndex < i - maxNumberOfPrimes; startingPrimeIndex++)
            {
                int sum = 0;
                int numberOfPrimes = 0;
                int currentPrimeIndex = startingPrimeIndex;
                while (sum < primes[i])
                {
                    sum += primes[currentPrimeIndex];
                    numberOfPrimes++;
                    currentPrimeIndex++;
                }
                if (! (sum == primes[i]))
                {
                    continue;
                }
                if (numberOfPrimes > maxNumberOfPrimes)
                {
                    maxNumberOfPrimes = numberOfPrimes;
                    specialPrime = primes[i];
                    Console.WriteLine($"Prime {specialPrime} is the sum of {maxNumberOfPrimes} primes.");
                }
            }
        }
    }
}