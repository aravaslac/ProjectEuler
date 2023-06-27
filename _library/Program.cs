using _library;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] list1 = { 1, 2, 3, 1, 2, 3};
        int[] list2 = { 1, 2, 2, 1, 2, 2, 1, 2, 2 };
        int[] list3 = { 1, 6, 6 };
        int[] list4 = { 1, 1, 1 };
        int[] list5 = { 1, 1, 1, 1, 2 };
        int[] list6 = { 1, 2, 1, 2, 1, 2 };

        Console.WriteLine(DigitOperations.CheckIsNPeriodic(list1.ToList(), 3));
        Console.WriteLine(DigitOperations.CheckIsNPeriodic(list2.ToList(), 3));
        Console.WriteLine(DigitOperations.CheckIsNPeriodic(list3.ToList(), 1));
        Console.WriteLine(DigitOperations.CheckIsNPeriodic(list4.ToList(), 1));
        Console.WriteLine(DigitOperations.CheckIsNPeriodic(list5.ToList(), 1));
        Console.WriteLine(DigitOperations.CheckIsNPeriodic(list6.ToList(), 2));
    }
}