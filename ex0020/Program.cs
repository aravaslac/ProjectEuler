using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        BigInteger factorial = 1;
        for (int i = 2; i < 101; i++)
        {
            factorial *= i;
        }
        string factorialString = $"{factorial}";
        long sumOfDigits = 0;
        foreach (char digit in factorialString)
        {
            sumOfDigits += int.Parse(digit.ToString());
        }
        Console.WriteLine(sumOfDigits);
        Console.ReadLine();
    }
}