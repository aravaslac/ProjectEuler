using _library;
using ex0074;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<BigInteger> loop1 = new HashSet<BigInteger>
        {
            169, 363601, 1454
        };
        HashSet<BigInteger> loop2 = new HashSet<BigInteger>
        {
            871, 45361
        };
        HashSet<BigInteger> loop3 = new HashSet<BigInteger>
        {
            872, 45362
        };

        //Remember to check for strong numbers!
        int valid = 0;
        for (int i = 1; i < 1_000_000; i++)
        {
            if (i % 50_000 == 0)
            {
                Console.WriteLine($"Milestone: {i}");
            }
            BigInteger number = i;
            int chain = 2;
            bool strongNumber = false;
            while (!loop1.Contains(number) && !loop2.Contains(number) && !loop3.Contains(number))
            {
                BigInteger newNumber = FactorialSum.GetSum(number);
                if (newNumber == number)
                {
                    strongNumber = true;
                    break;
                }
                number = newNumber;
                chain++;
            }
            if (strongNumber)
            {
                continue;
            }

            if (loop1.Contains(number))
            {
                chain++;
            }

            if (chain == 60)
            {
                valid++;
            }
        }
        Console.WriteLine("----------------------");
        Console.WriteLine(valid);
    }
}