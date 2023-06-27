using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _library;

//Source:
//https://proofwiki.org/wiki/Definition:Numerators_and_Denominators_of_Continued_Fraction

public static class ContinuedFractions
{
    //Given a continued fraction, returns the numerators of its sequence of convergents
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

    //Given a continued fraction, returns the denominators of its sequence of convergents
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
