using ex0021;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = Sieve.Primes(10000);
        List<int> amicable = new List<int>();
        for (int i = 2; i < 10000; i++)
        {
            if (primes.Contains(i) || amicable.Contains(i))
            {
                continue;
            }

            int[] properDivisors1 = ProperDivisors.Calculate(i);
            int sum1 = 0;
            foreach (int p in properDivisors1)
            {
                sum1 += p;
            }
            
            int candidate = sum1;
            if (primes.Contains(candidate) || candidate == i)
            {
                continue;
            }

            int[] properDivisors2 = ProperDivisors.Calculate(candidate);
            int sum2 = 0;
            foreach (int q in properDivisors2)
            {
                sum2 += q;
            }

            if (sum2 == i)
            {
                amicable.Add(i);

                if (candidate < 10000)
                {
                    amicable.Add(candidate);
                }
            }
        }

        int sum = 0;
        foreach(int j in amicable)
        {
            sum += j;
        }

        Console.WriteLine(sum);
        Console.ReadLine();

    }
}