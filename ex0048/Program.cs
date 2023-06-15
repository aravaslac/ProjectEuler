internal class Program
{
    private static void Main(string[] args)
    {
        //The problem can be solved using modulo arithmetics
        //(a + b) (mod m) = a (mod m) + b (mod m)
        //(a * b) (mod m) = a (mod m) * b (mod m)
        long sum = 0;
        long modulo = 10_000_000_000;
        for (int @base = 1; @base < 1000; @base++)
        {
            Console.WriteLine(@base);
            long product = 1;
            for (int exponent = 0; exponent < @base; exponent++)
            {
                product = (product * @base) % modulo;
            }
            sum = (sum + product) % modulo;
        }
        Console.WriteLine("--------------------");
        Console.WriteLine(sum);
    }
}