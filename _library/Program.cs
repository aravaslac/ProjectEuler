using _library;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] list1 = { 1, 2, 3, 4, 5 };
        int[] list2 = { 3, 4, 5, 2, 1 };
        int[] list3 = { 1, 6, 4, 3, 2 };
        int[] list4 = { 1, 6 };

        int[] list5 = { 1, 1, 1, 2, 2 };
        int[] list6 = { 1, 2, 1, 2, 1 };

        Console.WriteLine(Permutation.CheckPermutation(list1, list2));
        Console.WriteLine(Permutation.CheckPermutation(list1, list3));
        Console.WriteLine(Permutation.CheckPermutation(list1, list4));
        Console.WriteLine(Permutation.CheckPermutation(list5, list6));
    }
}