﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _library;

public static class Divisors
{
    public static int[] GetProperDivisors(int number)
    {
        List<int> divisors = new List<int>
        {
            1
        };
        for (int i = 2; i < number / 2 + 1; i++)
        {
            if (number % i == 0)
            {
                divisors.Add(i);
            }
        }
        return divisors.ToArray();
    }

    public static int GetGreatestCommonDivisor(List<int> numbers)
    {
        int[] primes = Sieve.GetPrimes(numbers.Max());
        List<int> factors = new List<int>();
        int index = 0;
        int gcd = 1;
        while (numbers.Max() > 1)
        {
            List<int> newNumbers = new List<int>();
            bool isFactor = true;
            bool lastIteration = true;
            foreach (int number in numbers)
            {
                if (number % primes[index] == 0)
                {
                    lastIteration = false;
                    newNumbers.Add(number / primes[index]);
                }
                else
                {
                    isFactor = false;
                    newNumbers.Add(number);
                }
            }
            if (isFactor)
            {
                factors.Add(primes[index]);
            }
            if (lastIteration)
            {
                index++;
            }
            numbers = newNumbers;
        }
        foreach (int factor in factors)
        {
            gcd *= factor;
        }
        return gcd;
    }

    public static int[] SimplifyFraction(int numerator, int denominator)
    {
        int gcd = GetGreatestCommonDivisor(new List<int> { numerator, denominator });
        int[] parts = new int[2];
        parts[0] = numerator/gcd;
        parts[1] = denominator/gcd;
        return parts;
    }
}
