using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] test = { 15, 22, 45, 88, 12, 5, 2, 3};
        var result = Permutation.GetPermutations(test);
        foreach (var permutation in result)
        {
            foreach (var item in permutation)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("-----------");
        Console.WriteLine(result.Count);
    }
}