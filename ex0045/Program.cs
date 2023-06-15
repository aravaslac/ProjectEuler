internal class Program
{
    private static void Main(string[] args)
    {
        int pentagonalIndex = 165;
        int hexagonalIndex = 143;
        long pentagonal = 40755;
        long hexagonal = 40755;
        bool looper = true;
        while (looper)
        {
            hexagonalIndex++;
            hexagonal = (2 * hexagonalIndex - 1) * hexagonalIndex;
            while (pentagonal < hexagonal)
            {
                pentagonalIndex++;
                pentagonal += 3 * pentagonalIndex - 2;
                Console.WriteLine($"p({pentagonalIndex}) = {pentagonal} | h({hexagonalIndex}) = {hexagonal}");
                if (pentagonal == hexagonal)
                {
                    looper = false;
                }
            }
        }
        Console.ReadLine();
    }
}