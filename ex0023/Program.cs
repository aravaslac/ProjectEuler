using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = Sieve.Primes(28123);
        List<int> abundantNumbers = new List<int>
        {
            12
        };

        //foreach (int number in primes)
        //{
        //    Console.Write($"{number}, ");
        //}

        for (int i = 14; i < 28123; i++)
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
        //foreach (int number in abundantNumbers)
        //{
        //    Console.Write($"{number}, ");
        //}

        List<int> sumOfTwoAbundants = new List<int>();
        foreach (int j in abundantNumbers)
        {
            Console.WriteLine(j);
            if (j > (int) 28124 / 2)
            {
                break;
            }
            for (int k = j; k < 28123 - j; k++)
            {
                int sum = j + k;
                if (!sumOfTwoAbundants.Contains(sum)) 
                {
                    sumOfTwoAbundants.Add(sum);
                    //Console.WriteLine(sum);
                }
            }
            
        }



        int sumOfViable = 0;
        for (int i = 1; i < 28123; i++)
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