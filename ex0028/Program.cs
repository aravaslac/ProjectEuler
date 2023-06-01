internal class Program
{
    private static void Main(string[] args)
    {
        //layers: 1, 3, 5 etc.
        //total numbers per layer: 4n-4
        long sum = 1;
        long number = 1;
        for (int i = 3; i < 1002;  i += 2)
        {
            for (int side = 0; side < 4; side++)
            {
                number += i - 1;
                sum += number;
            }
        }
        Console.WriteLine(sum);
    }
}