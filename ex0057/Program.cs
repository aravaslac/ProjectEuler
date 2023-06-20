using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        //Let f(n) be an iteration.
        //f(n) = 1 + q(n), where
        //q(n) = a(n)/b(n), a and b integers
        //Thus, f(n) = (a(n) + b(b))/b(n), where
        //a(n) = b(n-1) and b(n) = 2*b(n-1) + a(n-1)
        //a(1) = 1 and b(1) = 2

        BigInteger oldA = 1;
        BigInteger oldB = 2;
        int desirableResults = 0;
        for (int i = 2; i <= 1000;  i++)
        {
            BigInteger a = oldB;
            BigInteger b = 2 * oldB + oldA;
            BigInteger numerator = a + b;
            BigInteger denominator = b;
            Console.WriteLine($"{numerator}/{denominator}");
            string numeratorAsString = numerator.ToString();
            string denominatorAsString = denominator.ToString();
            if (numeratorAsString.Length > denominatorAsString.Length)
            {
                desirableResults++;
            }
            oldA = a;
            oldB = b;
        }
        Console.WriteLine("----------------------");
        Console.WriteLine(desirableResults);
    }
}