using System;
using System.Collections.Generic;
using System.Linq;

namespace _library;
public static class Sieve
{
    private static int _primeMagnitude = 1000;
    private static int _compositeMagnitude = 1000;
    private static HashSet<int> _primes;
    private static HashSet<int> _composites;

    static Sieve()
    {
        SetPrimes(_primeMagnitude);
        SetComposites(_compositeMagnitude);
    }

    /// <summary>
    /// Returns an array that is guaranteed to contain every prime up to the ceiling (inclusive), but can go further
    /// </summary>
    public static int[] GetQuickPrimes(int ceiling)
    {
        if (ceiling <= _primeMagnitude)
        {
            return _primes.ToArray();
        }
        while (_primeMagnitude < ceiling)
        {
            _primeMagnitude *= 10;
        }
        SetPrimes(_primeMagnitude);
        return _primes.ToArray();
    }

    /// <summary>
    /// Returns an array of every prime up to the given limit (inclusive)
    /// </summary>
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

        if (limit > _primeMagnitude)
        {
            while (_primeMagnitude < limit)
            {
                _primeMagnitude *= 10;
            }
            SetPrimes(_primeMagnitude);
        }

        if (limit == _primeMagnitude)
        {
            return _primes.ToArray();
        }

        HashSet<int> primes = new HashSet<int>();
        foreach (int prime in _primes)
        {
            if (prime <= limit)
            {
                primes.Add(prime);
            }
            else
            {
                break;
            }

        }
        return primes.ToArray();
    }

    /// <summary>
    /// Returns an array that is guaranteed to contain every composite up to the ceiling (inclusive), but can go further
    /// </summary>
    public static int[] GetQuickComposites(int ceiling)
    {
        if (ceiling <= _compositeMagnitude)
        {
            return _composites.ToArray();
        }
        while (_compositeMagnitude < ceiling)
        {
            _compositeMagnitude *= 10;
        }
        SetComposites(_compositeMagnitude);
        return _composites.ToArray();
    }

    /// <summary>
    /// Returns an array of every composite up to the given limit (inclusive)
    /// </summary>
    public static int[] GetComposites(int limit)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (limit < 2)
        {
            return new int[0];
        }

        if (limit > _compositeMagnitude)
        {
            while (_compositeMagnitude < limit)
            {
                _compositeMagnitude *= 10;
            }
            SetComposites(_compositeMagnitude);
        }

        if (limit == _compositeMagnitude)
        {
            return _composites.ToArray();
        }

        HashSet<int> composites = new HashSet<int>();
        foreach (int composite in _composites)
        {
            if (composite <= limit)
            {
                composites.Add(composite);
            }

        }
        return composites.ToArray();
    }

    private static void SetPrimes(int ceiling)
    {
        var numbers = AuxCalculation(ceiling);

        var primes = new HashSet<int>();
        for (int i = 2; i < ceiling + 1; i++)
        {
            if (numbers[i])
            {
                primes.Add(i);
            }
        }
        _primes = primes;
    }

    private static void SetComposites(int ceiling)
    {
        var numbers = AuxCalculation(ceiling);

        var composites = new HashSet<int>();
        for (int i = 4; i < ceiling + 1; i++)
        {
            if (!numbers[i])
            {
                composites.Add(i);
            }
        }
        _composites = composites;
    }

    private static bool[] AuxCalculation(int ceiling)
    {
        var numbers = new bool[ceiling + 1];
        numbers[0] = false;
        numbers[1] = false;
        for (int i = 2; i < ceiling + 1; i++)
        {
            numbers[i] = true;
        }

        int j = 2;
        while (j * j < ceiling + 1)
        {
            for (int k = 2 * j; k < ceiling + 1; k += j)
            {
                numbers[k] = false;
            }
            j++;
            while (!numbers[j])
            {
                j++;
            }
        }

        return numbers;
    }
}