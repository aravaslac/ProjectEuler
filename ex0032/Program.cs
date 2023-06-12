using ex0032;

internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<int> candidates = new HashSet<int>();
        for (int i = 1; i < 10000; i++)
        {
            int digitsOfI = DigitCounter.Digits(i);
            for (int j = 1; j < 10000; j++)
            {
                int k = i * j;
                int digitsofJ = DigitCounter.Digits(j);
                int digitsofK = DigitCounter.Digits(k);
                if (digitsOfI + digitsofJ + digitsofK != 9)
                {
                    continue;
                }
                List<int> ints = new List<int>
                {
                    i, j, k
                };
                HashSet<char> letters = new HashSet<char>();
                foreach (int member in  ints)
                {
                    foreach (char c in $"{member}")
                    {
                        letters.Add(c);
                    }
                }
                if (letters.Contains('0'))
                {
                    continue;
                }
                if (letters.Count == 9)
                {
                    Console.WriteLine($"{i} * {j} = {k}");
                    candidates.Add(k);
                }
                
            }
        }
        long sum = 0;
        foreach (int dude in candidates)
        {
            sum += dude;
        }
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine(sum);
        Console.ReadLine();
    }
}