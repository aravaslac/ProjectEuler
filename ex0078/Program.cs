using _library;
using ex0078;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        // Partitions
        // https://en.wikipedia.org/wiki/Pentagonal_number_theorem

        // p(n) = sum of (-1)^(k-1) * p * (n - g_k), where
        // g(k) = k*(3k-1)/2, for
        // k = 1, -1, 2, -2, 3, -3... while g(k) <= n

        // g(k) are the generalized pentagonal  numbers

        BigInteger partitions = 1;
        int n = 1;
        while (partitions % 1_000_000 != 0)
        {
            if (n % 1_000_000 == 0)
            {
                Console.WriteLine($"Milestone reached: {n}");
            }
            Partitions partition = new Partitions(n);
            partitions = partition.GetPartitions();
            n++;
        }
        Console.WriteLine();
        Console.WriteLine("----------------------");
        Console.WriteLine(n - 1);
    }
}