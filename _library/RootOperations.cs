using System;
using System.Numerics;

namespace _library;

public static class RootOperations
{
    /// <summary>
    /// Rationalizes fractions of the form 1/(sqrt(a) ± b).
    /// </summary>
    /// <returns>c, denominator of the fraction (sqrt(a) ∓ b)/c</returns>
    public static int GetRationalizedDenominator(int a, int b)
    {
        return a - b * b;
    }

    /// <summary>
    /// Calculates the square root digit by digit. Not very fast, but every digit is guaranteed to be correct.
    /// </summary>
    /// <param name="radicand">The radicand.</param>
    /// <param name="numberOfDigits">How many decimal places should be calculated.</param>
    /// <returns>A 2-tuple whose first term is the integer part of the root and the second term is an array of digits of the decimal part of the root.</returns>
    public static (int, int[]) GetSquareRootDigitByDigit(int radicand, int numberOfDigits)
    {
        // Source for the algorithm: https://math.stackexchange.com/a/512480

        int[] integerPairs = DigitOperations.GetDigitPairs(radicand);
        int integerPart = 0;
        BigInteger memory = 0;
        BigInteger remainder = 0;
        foreach (BigInteger pair in integerPairs)
        {
            remainder = 100 * remainder + pair;
            int digit = Iterate(ref remainder, ref memory);
            integerPart = 10 * integerPart + digit;
        }

        int[] expansion = new int[numberOfDigits];
        for (int i = 0; i < numberOfDigits; i++)
        {
            remainder *= 100;
            int digit = Iterate(ref remainder, ref memory);
            expansion[i] = digit;
        }

        return (integerPart, expansion);
    }

    private static int Iterate(ref BigInteger remainder, ref BigInteger memory)
    {
        int digit = -1;
        for (int i = 1; i < 10; i++)
        {
            if (i * (10 * memory + i) > remainder)
            {
                digit = i - 1;
                break;
            }
        }
        if (digit == -1)
        {
            digit = 9;
        }

        remainder -= digit * (10 * memory + digit);
        memory = 10 * memory + 2 * digit;
        return digit;
    }
}
