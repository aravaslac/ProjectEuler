using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = Sieve.GetPrimes(100000);
        int[] composites = Sieve.GetComposites(100000);
        int length = composites.Length;
        int specialNumber = 0;
        for (int i = 20; i < length; i++)
        {
            int number = composites[i];
            if (number % 2 == 0)
            {
                continue;
            }
            int maxRoot = ((int)Math.Sqrt((number - 3) / 2)) + 1;
            bool followsConjecture = false;
            for ( int root = 0; root < maxRoot; root++ )
            {
                int remainder = number - 2 * root * root;
                if ( remainder < 3)
                {
                    break;
                }
                int primeIndex = 1;
                int prime = primes[1];
                while (prime <= remainder)
                {
                    if ( prime == remainder)
                    {
                        Console.WriteLine($"{number} = {prime} + 2 * {root}^2");
                        followsConjecture = true;
                        break;
                    }
                    primeIndex++;
                    prime = primes[primeIndex];
                }
                if (followsConjecture)
                {
                    break;
                }

            }
            if (!followsConjecture)
            {
                specialNumber = number;
                break;
            } 
        }
        Console.WriteLine("---------------------");
        Console.WriteLine(specialNumber);
    }
}