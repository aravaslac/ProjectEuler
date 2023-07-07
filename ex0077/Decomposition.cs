using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _library;

namespace ex0077;

internal class Decomposition
{
    static int[] primes = new int[] { 2, 3 };
    static HashSet<int> primesHashSet = new HashSet<int> { 2, 3 };
    static int largestNumber = 3;
    static Dictionary<int, List<List<int>>> primeDecompositions = new Dictionary<int, List<List<int>>>();

    private int _n;

    internal Decomposition(int n)
    {
        _n = n;
        if (n > largestNumber)
        {
            primes = Sieve.GetQuickPrimes(n);
            primesHashSet = primes.ToHashSet();
            int oldLargestNumber = largestNumber;
            largestNumber = n;
            for (int i = oldLargestNumber + 1; i <= largestNumber; i++)
            {
                DecomposeInPrimes(i);
            }
        }
    }

    internal int GetNumberOfDecompositions()
    {
        if (primeDecompositions.ContainsKey(_n))
        {
            return primeDecompositions[_n].Count;
        }

        return 0;
    }

    internal List<List<int>> GetDecomposition()
    {
        if (primeDecompositions.ContainsKey(_n))
        {
            return primeDecompositions[_n].ToList();
        }
        return new List<List<int>>();
    }

    private void DecomposeInPrimes(int number)
    {
        List<List<int>> pairs = BreakIntoPairs(number);
        List<List<int>> decomposition = new List<List<int>>();
        foreach (List<int> pair in pairs)
        {
            bool firstIsPrime = primesHashSet.Contains(pair[0]);
            bool secondIsPrime = primesHashSet.Contains(pair[1]);
            if (firstIsPrime && secondIsPrime)
            {
                decomposition.Add(pair);
            }

            var reversedPair = new List<int> { pair[1], pair[0] };
            var decomposedSecondElement = FirstElementBreakdown(number, reversedPair, firstIsPrime, ref decomposition);

            if (pair[0] != pair[1])
            {
                FirstElementBreakdown(number, pair, secondIsPrime, ref decomposition);
            }

            foreach (var decompositionOfSecondElement in decomposedSecondElement)
            {
                List<int> candidate = decompositionOfSecondElement.ToList();
                candidate.Insert(0, pair[0]);
                FirstElementBreakdown(number, candidate, firstIsPrime, ref decomposition);
            }
        }

        if (decomposition.Count > 0)
        {
            primeDecompositions[number] = decomposition;
        }
    }

    private static List<List<int>> BreakIntoPairs(int number)
    {
        List<List<int>> pairs = new List<List<int>>();
        for (int i = 2; i <= number / 2; i++)
        {
            pairs.Add(new List<int> { i, number - i });
        }
        return pairs;
    }

    private static List<List<int>> FirstElementBreakdown(int number, List<int> list, bool isPrime, ref List<List<int>> decomposition)
    {
        List<List<int>> breakdown = new List<List<int>>();
        int firstElement = list[0];
        if (!primeDecompositions.ContainsKey(firstElement))
        {
            return breakdown;
        }

        foreach (var group in primeDecompositions[firstElement])
        {
            List<int> candidate = group.ToList();
            for (int i = 1; i < list.Count; i++)
            {
                candidate.Add(list[i]);
            }
            candidate.Sort();
            bool isValid = true;
            foreach (var element in breakdown)
            {
                if (element.SequenceEqual(candidate))
                {
                    isValid = false;
                    break;
                }
            }
            if (!isValid)
            {
                continue;
            }

            breakdown.Add(candidate);
            if (!isPrime)
            {
                continue;
            }
            AttemptToAddListToDecomposition(number, candidate, ref decomposition);
        }

        return breakdown;
    }

    private static void AttemptToAddListToDecomposition (int number, List<int> candidate, ref List<List<int>> decomposition)
    {
        int sum = 0;
        foreach (int part in  candidate)
        {
            sum += part;
        }
        if (sum != number)
        {
            return;
        }

        bool isValid = true;
        foreach (var element in decomposition)
        {
            if (element.SequenceEqual(candidate))
            {
                isValid = false;
                break;
            }
        }

        if (isValid)
        {
            decomposition.Add(candidate);
        }
    }

}
