internal class Program
{
    private static void Main(string[] args)
    {
        int bestP = 3;
        int max = 0;
        for (int p = 3; p < 1001; p++)
        {
            Console.WriteLine(p);
            int count = 0;
            for (int c = p/3; c < p-1; c++)
            {
                for (int b = 1; b < c; b++)
                {
                    int a = p - b - c;
                    if (a > 0 && a <= b && a*a + b*b == c * c)
                    {
                        count++;
                    }
                }
            }
            if (count > max)
            {
                max = count;
                bestP = p;
            }
        }
        Console.WriteLine("---------------------------");
        Console.Write(bestP);
    }
}