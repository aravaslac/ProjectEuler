using _library;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] list1 = { 1, 2, 3, 4};

        var list2 = ListOperations.LeftShift(list1.ToList(), 2);
        var list3 = ListOperations.LeftShift(list1.ToList(), 1);
        var list4 = ListOperations.LeftShift(list1.ToList(), 0);
        var list5 = ListOperations.LeftShift(list1.ToList(), 7);

        foreach ( var i in list2)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();

        foreach (var i in list3)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();

        foreach (var i in list4)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();

        foreach (var i in list5)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }
}