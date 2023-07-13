using _library;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        //https://oeis.org/A102341
        //Triangles x = y = z +/- 1.
        //x+y+z must be even, so z = 2k
        //Thus, (x+y+z)/2 = 3k +/- 1
        //A = k*sqrt(3*k^2 +/- 4*k + 1)
        //If the term 3*k^2 + 1 +/- 4k is a perfect square, A is an integer.


        long LIMIT = 1_000_000_000;
        BigInteger sum = 0;
        long perimeter = 0;
        long k = 2;
        int signal = 1;
        bool negativeIteration = true;
        
        do
        {
            if (negativeIteration)
            {
                negativeIteration = false;
                signal = -1;
            }
            else
            {
                negativeIteration = true;
                signal = 1;
            }

            perimeter = 2 * (3 * k + signal);
            long term = 3 * k * k + 1 + signal * 4 * k;
            
            if (FigurateNumbers.CheckPerfectSquare(term))
            {
                sum += perimeter;
                Console.Write($"({2*k + signal},{2 * k + signal},{2*k},{perimeter}) ");
            }
            
            if (negativeIteration)
            {
                k++;
            }
        }
        while (perimeter < LIMIT);

        Console.WriteLine("--------------------------------");
        Console.WriteLine(sum);
    }
}