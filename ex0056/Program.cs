using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        BigInteger max = 0;
        for (int a = 2; a < 100;  a++)
        {
            Console.WriteLine($"a = {a}");
            for (int b = 1; b < 100; b++)
            {
                BigInteger product = 1;
                for (int i = 0; i < b; i++)
                {
                    product *= a;
                }
                BigInteger sum = 0;
                while (product > 0)
                {
                    sum += product % 10;
                    product /= 10;
                }
                if (sum > max)
                {
                    max = sum;
                }
            }
        }
        Console.WriteLine(max);
    }
}