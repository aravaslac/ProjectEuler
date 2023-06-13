internal class Program
{
    private static void Main(string[] args)
    {
        int sum = 0;
        int ceiling = 10000;
        int[] primes = _library.Sieve.GetPrimes(ceiling);
        int counter = 11;
        int primeIndex = 3;
        int maxPrimeIndex = primes.Length - 1;
        while (counter > 0)
        {
            if (primeIndex == maxPrimeIndex)
            {
                ceiling *= 10;
                primes = _library.Sieve.GetPrimes(ceiling);
                maxPrimeIndex = primes.Length - 1;
            }
            primeIndex++;
            int prime = primes[primeIndex];
            bool goodCandidate = true;

            //Right side
            var rightSidePrimes = new List<int>();
            int remainder = prime;

            while (remainder > 9)
            {
                remainder = _library.DigitOperations.RemoveRightDigit(remainder);
                if (! primes.Contains(remainder) )
                {
                    goodCandidate = false;
                    break;
                }
                rightSidePrimes.Add(remainder);
            }
            if ( ! goodCandidate )
            {
                continue;
            }

            //Left side
            var leftSidePrimes = new List<int>();
            remainder = prime;

            while (remainder > 9)
            {
                remainder = _library.DigitOperations.RemoveLeftDigit(remainder);
                if (!primes.Contains(remainder))
                {
                    goodCandidate = false;
                    break;
                }
                leftSidePrimes.Add(remainder);
            }
            if (!goodCandidate)
            {
                continue;
            }

            sum += prime;
            counter--;

            Console.Write(prime);
            foreach (var righty in rightSidePrimes)
            {
                Console.Write($" - {righty}");
            }
            Console.WriteLine();


            Console.Write(prime);
            foreach ( var lefty  in leftSidePrimes)
            {
                Console.Write($" - {lefty}");
            }
            Console.WriteLine();

        }
        Console.WriteLine("-------------------------------");
        Console.WriteLine(sum);
    }
}