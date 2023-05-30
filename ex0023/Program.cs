using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = Sieve.Primes(28124);
        List<int> abundantNumbers = new List<int>
        {
            12
        };

        for (int i = 14; i < 28124; i++)
        {
            if (primes.Contains(i))
            {
                continue;
            }
            int[] properDivisors = ProperDivisors.Calculate(i);
            int sum = 0;
            foreach (int p in properDivisors)
            {
                sum += p;
            }
            if (sum > i)
            {
                abundantNumbers.Add(i);
            }
        }

        List<int> sumOfTwoAbundants = new List<int>();
        foreach (int j in abundantNumbers)
        {
            foreach (int k in abundantNumbers)
            {              
                    int sum = j + k;
                    if (sum < 28124 && !sumOfTwoAbundants.Contains(sum))
                    {
                        sumOfTwoAbundants.Add(sum);
                    }
            }
        }
        int sumOfViable = 0;
        for (int i = 1; i < 28124; i++)
        {
            if (!sumOfTwoAbundants.Contains(i))
            {
                sumOfViable += i;
            }
        }

        Console.WriteLine(sumOfViable);
        Console.ReadLine();
    }
}