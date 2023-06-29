using System;
using System.Collections.Generic;

namespace _library;

public class Fraction : IComparable<Fraction>, IEquatable<Fraction>
{

    private static int primeMagnitude = 1;
    private static int[] primes = new int[1] {2};

    private int _numerator;
    private int _denominator;

    public Fraction (int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    public override int GetHashCode()
    {
        return 31 * _numerator + 17 * _denominator;
    }

    public override bool Equals(object obj)
    {
        return obj is Fraction fraction && Equals(fraction);
    }

    public bool Equals(Fraction other)
    {
        return _numerator == other._numerator && _denominator == other._denominator;
    }

    public override string ToString()
    {
        return $"frac({_numerator}/{_denominator})";
    }

    public int GetDenominator()
    {
        return _denominator;
    }

    public int GetNumerator()
    {
        return _numerator;
    }

    public (int,int) GetFractionParts()
    {
        return (_numerator, _denominator);
    }

    public double GetFractionAsDouble()
    {
        return (double)_numerator / _denominator;
    }

    public int CompareTo(Fraction other)
    {
        long thisMultiplied = _numerator * other._denominator;
        long otherMultiplied = _denominator * other._numerator;
        return (int)(thisMultiplied - otherMultiplied);
    }

    public Fraction Simplify()
    {
        if (_numerator > primeMagnitude || _denominator > primeMagnitude)
        {
            PrepareMorePrimes(Math.Max(_numerator, _denominator));
        }

        int gcd = Divisors.GetGreatestCommonDivisor(new List<int> { _numerator, _denominator }, primes);
        
        return new Fraction(_numerator/gcd, _denominator/gcd);
    }

    private static void PrepareMorePrimes(int number)
    {
        while (primeMagnitude < number)
        {
            primeMagnitude *= 10;
        }
        primes = Sieve.GetQuickPrimes(primeMagnitude);
    }
}
