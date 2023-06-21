using ex0060;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] factorizationPrimes = _library.Sieve.GetPrimes(100_000);
        int[] primes = _library.Sieve.GetPrimes(10_000);
        int primesListLength = primes.Length;
        long maxPrime = primes[primesListLength - 1];
        HashSet<int> testPrimes = primes.ToHashSet();
        List<List<int>> validFamilies = new List<List<int>>();
        for (int firstIndex = 1; firstIndex < primesListLength - 1; firstIndex++)
        {
            for (int secondIndex = firstIndex + 1; secondIndex < primesListLength; secondIndex++)
            {
                int[] family = new int[] { primes[firstIndex], primes[secondIndex] };
                long[] permutations = Permutations.GetPermutations(family);
                bool isValid = true;
                foreach (long permutation in permutations)
                {
                    if (permutation <= maxPrime)
                    {
                        isValid = testPrimes.Contains((int) permutation);
                    }
                    else
                    {
                        isValid = _library.PrimeFactorization.CheckPrimalityViaFactorization(permutation, factorizationPrimes);
                    }
                    if (!isValid)
                    {
                        break;
                    }
                }
                if (!isValid)
                {
                    continue;
                }
                validFamilies.Add(new List<int> { family[0], family[1] });
            }
        }
        Console.WriteLine($"Valid pairs: {validFamilies.Count}");
        Console.WriteLine("-------------------------");

        string[] nameStrings = new string[]
        {
            "trios", "quads", "quints"
        };

        for (int iterations = 0; iterations < 3; iterations++)
        {
            List<List<int>> newValidFamilies = new List<List<int>>();
            for (int index = 1; index < primesListLength; index++)
            {
                int prime = primes[index];
                foreach (var validFamily in validFamilies)
                {
                    if (validFamily.Contains(prime))
                    {
                        continue;
                    }

                    List<int> family = validFamily.ToList();
                    family.Add(prime);
                    long[] newPermutations = Permutations.GetNewPermutations(validFamily, prime);

                    bool isValid = true;
                    foreach (long permutation in newPermutations)
                    {
                        if (permutation <= maxPrime)
                        {
                            isValid = testPrimes.Contains((int)permutation);
                        }
                        else
                        {
                            isValid = _library.PrimeFactorization.CheckPrimalityViaFactorization(permutation, factorizationPrimes);
                        }
                        if (!isValid)
                        {
                            break;
                        }
                    }
                    if (!isValid)
                    {
                        continue;
                    }
                    newValidFamilies.Add(family);

                    if (iterations == 2)
                    {
                        foreach (var dude in family)
                        {
                            Console.Write($"{dude} ");
                        }
                        Console.WriteLine();
                    }

                }
            }
            validFamilies = newValidFamilies.ToList();

            Console.WriteLine("-----------------------");
            Console.WriteLine($"Valid {nameStrings[iterations]}: {newValidFamilies.Count}");
            Console.WriteLine("-------------------------");

        }
        Console.WriteLine("---------------------------");
        Console.WriteLine("---------------------------");
        long minimum = long.MaxValue;
        foreach (var family in validFamilies)
        {
            long sum = 0;
            foreach (var p in family)
            {
                sum += p;
            }
            if (sum < minimum)
            {
                minimum = sum;
            }
        }

        Console.WriteLine(minimum);
    }
}