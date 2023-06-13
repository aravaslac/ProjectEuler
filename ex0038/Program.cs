internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<int> candidates = new HashSet<int>();
        for (int i = 1; i < 100000000; i++)
        {
            int j = 1;
            string concatProduct = (i * j).ToString();
            while (concatProduct.Length < 9)
            {
                j++;
                concatProduct += (i * j).ToString();
            }
            if (concatProduct.Length > 9 || j == 1)
            {
                continue;
            }

            int intConcatProduct = int.Parse(concatProduct);
            if (! _library.DigitOperations.CheckIsPandigital(intConcatProduct))
            {
                continue;
            }

            bool freshCandidate = candidates.Add(intConcatProduct);
            if (freshCandidate)
            {
                Console.WriteLine($"i = {i}; n = {intConcatProduct}");
            }
        }
        int max = 0;
        foreach (int candidate in candidates)
        {
            if (candidate > max)
            {
                max = candidate;
            }
        }
        Console.WriteLine("-----------------------");
        Console.WriteLine(max);
    }
}