using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        const int VALUE = 50_000_000;
        int[] primes = Sieve.GetPrimes(VALUE);

        int index2 = 0;
        int index3 = 0;
        int index4 = 0;
        long power2 = primes[index2] * primes[index2];
        long power3 = primes[index3] * primes[index3] * primes[index3];
        long power4 = primes[index4] * primes[index4] * primes[index4] * primes[index4];

        HashSet<long> numbers = new HashSet<long>();

        while (power4 <= VALUE)
        {
            while (power3 <= VALUE)
            {
                while (power2 <= VALUE)
                {
                    long number = power2 + power3 + power4;
                    if (number < VALUE && numbers.Add(number))
                    {
                        Console.WriteLine($"{power2}^2 + {power3}^3 + {power4}^4 = {number}");
                    }
                    index2++;
                    power2 = primes[index2] * primes[index2];
                }

                index3++;
                power3 = primes[index3] * primes[index3] * primes[index3];
                index2 = 0;
                power2 = 4;

            }
            index4++;
            power4 = primes[index4] * primes[index4] * primes[index4] * primes[index4];
            index3 = 0;
            index2 = 0;
            power3 = 8;
            power2 = 4;
        }

        Console.WriteLine("-------------------------------");
        Console.WriteLine(numbers.Count);
    }
}