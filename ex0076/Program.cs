using ex0076;
using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        //Decomposition decomposition = new Decomposition(50);
        //This was fun and all, but running time is impossibly high. It had to be redone.

        // Using https://en.wikipedia.org/wiki/Gaussian_binomial_coefficient

        // Actually it just ocurred to me that these are simple partitions.

        Polynomial dividend = new Polynomial(199, 100);
        Polynomial divisor = new Polynomial(100, 1);
        Console.WriteLine(dividend.EuclideanDivision(divisor).Item1.GetCoefficients()[100]);
    }
}