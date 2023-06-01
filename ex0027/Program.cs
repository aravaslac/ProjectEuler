internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = Sieve.Primes(1000);

        int bestConsecutivePrimes = 0;
        int bestA = 0;
        int bestB = 0;
        for (int a = -999; a < 1000; a++)
        {
            for (int b = -1000; b < 1001; b++)
            {
                int consecutivePrimes = 0;
                bool looper = true;
                for ( int i = 0; i < 1000; i++)
                {
                    if (primes.Contains(i*i + a*i + b))
                    {
                        consecutivePrimes++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (consecutivePrimes > bestConsecutivePrimes)
                {
                    bestConsecutivePrimes = consecutivePrimes;
                    bestA = a;
                    bestB = b;
                }

                Console.WriteLine($"{a} {b} {consecutivePrimes};   {bestA} {bestB} {bestConsecutivePrimes}");
            }
        }

        Console.WriteLine(bestA * bestB);
        Console.ReadLine();
    }
}