internal class Program
{
    private static void Main(string[] args)
    {
        for (int c = 3; c < 998; c++)
        {
            for (int b = 2; b < c; b++)
            {
                for (int a = 1; a < b; a++)
                {
                    if (a + b + c == 1000 && a * a + b * b == c * c)
                    {
                        Console.WriteLine(a * b * c);
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}