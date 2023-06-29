using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        // from https://en.wikipedia.org/wiki/Euler%27s_totient_function
        // n/phi(n) = rad(n)/phi(rad(n)), where rad(n) is the product of all distinct prime divisors of n
        // therefore, phi(n) = phi(rad(n))*n/rad(n)

        int[] primes = Sieve.GetPrimes(9_999_999);
        int[] composites = Sieve.GetComposites(9_999_999);
        int n = 0;
        double minValue = double.PositiveInfinity;
        foreach (int i in composites)
        {
            HashSet<int> uniqueFactors = PrimeFactorization.GetUniqueFactors(i, primes);

            int radical = 1;
            foreach (int factor in uniqueFactors)
            {
                radical *= factor;
            }

            int radPhi = 1;
            foreach (int factor in uniqueFactors)
            {
                radPhi *= factor - 1;
            }

            double value = (double)radical/radPhi;
            if (value > minValue)
            {
                continue;
            }

            int ratio = 1;
            if (radical != i)
            {
                ratio = i/radical;
            }
            int phi = radPhi * ratio;

            if (DigitOperations.GetNumberOfDigits(phi) != DigitOperations.GetNumberOfDigits(i))
            {
                continue;
            }

            string[] digitsOfI = DigitOperations.GetDigits(i);
            string[] digitsOfPhi = DigitOperations.GetDigits(phi);
            if (!Permutation.CheckPermutation(digitsOfI, digitsOfPhi))
            {
                continue;
            }

            Console.WriteLine($"n = {i}; phi = {phi}; n/phi = {value}");
            minValue = value;
            n = i;
        }
        Console.WriteLine("----------------------");
        Console.WriteLine($"Answer: {n}");
    }
}