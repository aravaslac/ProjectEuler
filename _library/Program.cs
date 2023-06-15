using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = Sieve.GetPrimes(17);
        foreach (int i in primes)
        {
            Console.WriteLine(i);
        }
        
    }
}