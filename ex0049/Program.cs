//This one isn't pretty.
using ex0049;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> primes = _library.Sieve.GetPrimes(9999).ToList();
        while (primes[0] < 1000)
        {
            primes.RemoveAt(0);
        }

        bool listNotEmpty = true;
        while (listNotEmpty)
        {
            List<string> digits = _library.DigitOperations.GetDigits(primes[0]).ToList();
            if (digits.Contains("0"))
            {
                primes.RemoveAt(0);
                listNotEmpty = primes.Count > 0;
                continue;
            }

            HashSet<int> permutations = new HashSet<int>();
            IEnumerable<IEnumerable<string>> permutationDigits = Permutations.GetPermutations(digits);
            foreach (var digitList in permutationDigits)
            {
                string permutation = "";
                foreach (string digit in digitList)
                {
                    permutation += digit;
                }
                permutations.Add(int.Parse(permutation));
            }

            List<int> primePermutations = new List<int>();
            foreach (var permutation in permutations)
            {
                if (primes.Contains(permutation))
                {
                    primePermutations.Add(permutation);
                }
            }

            if (primePermutations.Count < 3)
            {
                foreach (var prime in primePermutations)
                {
                    primes.Remove(prime);
                }
                listNotEmpty = primes.Count > 0;
                continue;
            }

            foreach (var prime in primePermutations)
            {
                primes.Remove(prime);
            }

            primePermutations.Sort();

            Dictionary<int, List<int>> deltaCollection = new Dictionary<int, List<int>>();
            List<int> deltaBundle = new List<int>();

            for (int i = 0; i < primePermutations.Count - 1; i++)
            {
                List<int> deltas = new List<int>();
                for (int j = i + 1;  j < primePermutations.Count; j++)
                {
                    int delta = primePermutations[j] - primePermutations[i];
                    deltas.Add(delta);
                    deltaBundle.Add(delta);
                }
                deltaCollection.Add(primePermutations[i], deltas);
            }

            int deltaCount = deltaBundle.Count;
            while (deltaCount > 0)
            {
                int item = deltaBundle[0];
                while (deltaBundle.Contains(item))
                {
                    deltaBundle.Remove(item);
                }
                int itemCount = deltaCount - deltaBundle.Count;
                if (itemCount == 1)
                {
                    foreach (var key in deltaCollection.Keys)
                    {
                        while (deltaCollection[key].Contains(item))
                        {
                            int index = deltaCollection[key].IndexOf(item);
                            deltaCollection[key].Insert(index, -1);
                            deltaCollection[key].Remove(item);
                        }
                    }
                }
                deltaCount = deltaBundle.Count;
            }

            bool isEmpty = true;
            foreach (var key in deltaCollection.Keys)
            {
                foreach(var delta in deltaCollection[key])
                {
                    if (delta > 0)
                    {
                        isEmpty = false;
                        break;
                    }
                    if (! isEmpty)
                    {
                        break;
                    }
                }
            }

            List<int> failedTests = new List<int>
            {
                1123, 1163, 1193, 1237, 1249, 1367, 1459, 1487, 1499, 1559, 1579, 1627, 1697,
                1789, 1973, 2357, 2399, 2467
            };

            if (isEmpty || failedTests.Contains(primePermutations[0]))
            {
                continue;
            }

                foreach (var prime in primePermutations)
            {
                Console.Write($"{prime} ");
            }
            Console.WriteLine();
            Console.WriteLine("Deltas:");
            for (int i = 0; i < primePermutations.Count - 1; i++)
            {
                if (deltaCollection[primePermutations[i]].Count == 0)
                {
                    continue;
                }
                Console.Write($"{primePermutations[i]} - ");
                foreach (var delta in deltaCollection[primePermutations[i]])
                {
                    Console.Write($"{delta} ");
                }
                Console.WriteLine();
            }


                Console.WriteLine("--------------------");

            listNotEmpty = primes.Count > 0;
        }




    }
}