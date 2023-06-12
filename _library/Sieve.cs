using System;
using System.Collections.Generic;

namespace _library;
public static class Sieve
{
    public static int[] GetPrimes(int limit)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (limit < 2)
        {
            return new int[0];
        }

        var numbers = new bool[limit + 1];
        numbers[0] = false;
        numbers[1] = false;
        for (int i = 2; i < limit + 1; i++)
        {
            numbers[i] = true;
        }

        int j = 2;
        while (j * j < limit + 1)
        {
            for (int k = 2 * j; k < limit + 1; k += j)
            {
                numbers[k] = false;
            }
            j++;
        }

        var primes = new List<int>();
        for (int i = 1; i < limit + 1; i++)
        {
            if (numbers[i])
            {
                primes.Add(i);
            }
        }
        return primes.ToArray();
    }
}