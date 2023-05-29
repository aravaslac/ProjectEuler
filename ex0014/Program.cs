internal class Program
{
    private static void Main(string[] args)
    {
        int maxSequenceSize = 0;
        int ownerOfMaxSequenceSize = 1;

        for (int seed = 2; seed < 1_000_000; seed++)
        {
            long number = seed;
            int sequenceSize = 1;
            while (number > 1)
            {
                if (number % 2 == 0)
                {
                    number /= 2;
                }
                else
                {
                    number = 3 * number + 1;
                }
                sequenceSize++;
            }

            if (sequenceSize > maxSequenceSize)
            {
                maxSequenceSize = sequenceSize;
                ownerOfMaxSequenceSize = seed;
            }
        }

        Console.WriteLine(ownerOfMaxSequenceSize);
        Console.ReadLine();
    }
}