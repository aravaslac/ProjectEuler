internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = _library.Sieve.GetPrimes(17);
        long sum = 0;
        for (long i = 1_023_456_789; i < 9_876_543_211; i++)
        {
            string numberAsString = i.ToString();
            int[] pieces = new int[7];
            bool notGood = false;
            for (int j = 0; j < 7; j++)
            {
                int piece = int.Parse(numberAsString.Substring(j + 1, 3));
                if (piece % primes[j] != 0)
                {
                    notGood = true;
                    break;
                }
                pieces[j] = piece;
            }

            if (notGood)
            {
                continue;
            }

            if (! _library.DigitOperations.CheckIsTenPandigital(i))
            {
                continue;
            }

            

            Console.Write($"{i} = ");
            foreach (int piece in pieces)
            {
                Console.Write($"{piece} ");
            }
            Console.WriteLine();

            sum += i;
        }

        Console.WriteLine("----------------------");
        Console.WriteLine(sum);
    }
}