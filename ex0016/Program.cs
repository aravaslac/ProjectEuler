using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        BigInteger power = 1;
        for (int i = 0; i < 1000; i++)
        {
            power *= 2;
        }
        string powerString = $"{power}";
        long sumOfDigits = 0;
        foreach (char digit in powerString)
        {
            sumOfDigits += int.Parse(digit.ToString());
        }
        Console.WriteLine(sumOfDigits);
        Console.ReadLine();
    }
}