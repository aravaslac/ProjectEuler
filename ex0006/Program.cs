internal class Program
{
    private static void Main(string[] args)
    {
        long sum = 0L;
        for (int i = 1; i < 101; i++)
        {
            for (int j = 1; j < 101; j++)
            {
                if (i != j)
                {
                    sum += (long)i*j;
                }
            }
        }
        Console.WriteLine(sum);
        Console.ReadLine();
    }
}