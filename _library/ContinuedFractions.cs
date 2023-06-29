using System;
using System.Collections.Generic;
using System.Numerics;

namespace _library;

//Source:
//https://proofwiki.org/wiki/Definition:Numerators_and_Denominators_of_Continued_Fraction

public static class ContinuedFractions
{
    /// <summary>
    /// Gets the continued fraction representation of a square root
    /// </summary>
    /// <param name="n">Not a square number</param>
    /// <returns>An array containing a0 followed by the period.</returns>
    public static int[] GetContinuedFraction(int n)
    {
        //form: numerator/(sqrt(n) - b)
        int a0 = (int)Math.Sqrt(n);
        int b = a0;
        int numerator = 1;
        List<int> period = new List<int>();
        List<int> bValues = new List<int>();
        List<int> numeratorValues = new List<int>();
        bool periodBuilder = true;
        int size = 0;
        while (periodBuilder)
        {
            int aN = (int)(numerator / (Math.Sqrt(n) - b));
            numerator = _library.RootOperations.GetRationalizedDenominator(n, b) / numerator;
            b = numerator * aN - b;

            period.Add(aN);
            bValues.Add(b);
            numeratorValues.Add(numerator);
            size = period.Count;

            if (size % 2 == 0
                    && _library.DigitOperations.CheckIsNPeriodic(period, size / 2)
                    && _library.DigitOperations.CheckIsNPeriodic(bValues, size / 2)
                    && _library.DigitOperations.CheckIsNPeriodic(numeratorValues, size / 2)
               )
            {
                periodBuilder = false;
            }
        }

        while (period.Count > size / 2)
        {
            period.RemoveAt(0);
        }

        period.Insert(0, a0);
        return period.ToArray();
    }

    /// <summary>
    /// Gets the numerators of the series of convergents of a given continued fraction.
    /// </summary>
    /// <param name="continuedFraction">An array containing a continued fraction representation of a number.</param>
    /// <returns>An array containing the numerators of the convergents.</returns>
    public static BigInteger[] GetConvergentNumerators(int[] continuedFraction)
    {
        int size = continuedFraction.Length;
        List<BigInteger> convergentNumerators = new List<BigInteger>();
        if (size == 0)
        {
            return convergentNumerators.ToArray();
        }

        convergentNumerators.Add(continuedFraction[0]);
        if (size == 1)
        {
            return convergentNumerators.ToArray();
        }

        convergentNumerators.Add(continuedFraction[1] * continuedFraction[0] + 1);
        if (size == 2)
        {
            return convergentNumerators.ToArray();
        }

        for (int i = 2; i < size; i++)
        {
            BigInteger number = continuedFraction[i] * convergentNumerators[i - 1] + convergentNumerators[i - 2];
            convergentNumerators.Add(number);
        }
        return convergentNumerators.ToArray();
    }

    /// <summary>
    /// Gets the denominators of the series of convergents of a given continued fraction.
    /// </summary>
    /// <param name="continuedFraction">An array containing a continued fraction representation of a number.</param>
    /// <returns>An array containing the denominators of the convergents.</returns>
    public static BigInteger[] GetConvergentDenominators(int[] continuedFraction)
    {
        int size = continuedFraction.Length;
        List<BigInteger> convergentDenominators = new List<BigInteger>();
        if (size == 0)
        {
            return convergentDenominators.ToArray();
        }

        convergentDenominators.Add(1);
        if (size == 1)
        {
            return convergentDenominators.ToArray();
        }

        convergentDenominators.Add(continuedFraction[1]);
        if (size == 2)
        {
            return convergentDenominators.ToArray();
        }

        for (int i = 2; i < size; i++)
        {
            BigInteger number = continuedFraction[i] * convergentDenominators[i - 1] + convergentDenominators[i - 2];
            convergentDenominators.Add(number);
        }
        return convergentDenominators.ToArray();
    }
}
