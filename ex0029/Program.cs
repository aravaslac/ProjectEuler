internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<List<int>> factorCombinations = new HashSet<List<int>>();
        for (int i = 2; i < 101; i++)
        {
            factorCombinations.Add(PrimeFactorization.Factorize(i));
        }

        //OK

        HashSet<List<int>> poweredFactorCombinations = new HashSet<List<int>>();

        foreach (var combination in factorCombinations)
        {
            var poweredCombination = combination;
            for (int j = 1; j < 100; j++)
            {
                poweredCombination = poweredCombination.Concat(combination).ToList();
                poweredCombination.Sort();
                bool notPresent = true;
                foreach (var existingCombination in poweredFactorCombinations)
                {
                    if (existingCombination.SequenceEqual(poweredCombination))
                    {
                        notPresent = false;
                        break;
                    }
                }
                if (notPresent)
                {
                    poweredFactorCombinations.Add(poweredCombination);
                }
                
            }
        }



        Console.WriteLine(poweredFactorCombinations.Count);


    }
}