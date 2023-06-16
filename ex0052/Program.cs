internal class Program
{
    private static void Main(string[] args)
    {
        int powerOfTen = 1;
        long winner = 0;
        bool notFound = true;
        while (notFound)
        {
            //It's easy to see that the first digit always has to be 1.
            long size = (long)Math.Pow(10, powerOfTen);
            for (long number = size; number < 2 * size; number++)
            {
                if (number == 142857)
                {
                    Console.WriteLine("Debug time");
                }
                string numberAsString = number.ToString();
                int length = numberAsString.Length;
                string[] permutations = _library.Permutations.GetAnagrams(numberAsString);

                long sum = number;
                bool isValid = true;
                for (int i = 0; i < 5; i++)
                {
                    sum += number;
                    string sumAsString = sum.ToString();
                    if (sumAsString.Length > length || !permutations.Contains(sumAsString))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    winner = number;
                    notFound = false;
                    break;
                }
            }
            powerOfTen++;
        }

        Console.WriteLine(winner);
        long winningSum = winner;
        for (int i = 0; i < 5; i++)
        {
            winningSum += winner;
            Console.WriteLine(winningSum);
        }

    }
}