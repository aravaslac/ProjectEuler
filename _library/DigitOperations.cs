using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _library;

public static class DigitOperations
{
    public static int GetNumberOfDigits(this int n)
    {
        if (n >= 0)
        {
            if (n < 10) return 1;
            if (n < 100) return 2;
            if (n < 1000) return 3;
            if (n < 10000) return 4;
            if (n < 100000) return 5;
            if (n < 1000000) return 6;
            if (n < 10000000) return 7;
            if (n < 100000000) return 8;
            if (n < 1000000000) return 9;
            return 10;
        }
        else
        {
            if (n > -10) return 2;
            if (n > -100) return 3;
            if (n > -1000) return 4;
            if (n > -10000) return 5;
            if (n > -100000) return 6;
            if (n > -1000000) return 7;
            if (n > -10000000) return 8;
            if (n > -100000000) return 9;
            if (n > -1000000000) return 10;
            return 11;
        }
    }

    public static int GetNumberOfDigits(this long n)
    {
        if (n >= 0)
        {
            if (n < 10L) return 1;
            if (n < 100L) return 2;
            if (n < 1000L) return 3;
            if (n < 10000L) return 4;
            if (n < 100000L) return 5;
            if (n < 1000000L) return 6;
            if (n < 10000000L) return 7;
            if (n < 100000000L) return 8;
            if (n < 1000000000L) return 9;
            if (n < 10000000000L) return 10;
            if (n < 100000000000L) return 11;
            if (n < 1000000000000L) return 12;
            if (n < 10000000000000L) return 13;
            if (n < 100000000000000L) return 14;
            if (n < 1000000000000000L) return 15;
            if (n < 10000000000000000L) return 16;
            if (n < 100000000000000000L) return 17;
            if (n < 1000000000000000000L) return 18;
            return 19;
        }
        else
        {
            if (n > -10L) return 2;
            if (n > -100L) return 3;
            if (n > -1000L) return 4;
            if (n > -10000L) return 5;
            if (n > -100000L) return 6;
            if (n > -1000000L) return 7;
            if (n > -10000000L) return 8;
            if (n > -100000000L) return 9;
            if (n > -1000000000L) return 10;
            if (n > -10000000000L) return 11;
            if (n > -100000000000L) return 12;
            if (n > -1000000000000L) return 13;
            if (n > -10000000000000L) return 14;
            if (n > -100000000000000L) return 15;
            if (n > -1000000000000000L) return 16;
            if (n > -10000000000000000L) return 17;
            if (n > -100000000000000000L) return 18;
            if (n > -1000000000000000000L) return 19;
            return 20;
        }
    }

    public static string[] GetDigits(int number)
    {
        int numberOfDigits = GetNumberOfDigits(number);
        List<string> digits = new List<string>();
        for (int i = 0; i < numberOfDigits; i++)
        {
            digits.Add($"{number % 10}");
            number /= 10;
        }
        digits.Reverse();
        return digits.ToArray();
    }

    public static int RemoveLeftDigit(int n)
    {
        return int.Parse($"{n}".Substring(1));
    }

    public static int RemoveRightDigit(int n)
    {
        return n / 10;
    }

    public static bool CheckIsPandigital(int number)
    {
        int numberOfDigits = GetNumberOfDigits(number);
        char numberOfDigitsAsChar = numberOfDigits.ToString()[0];
        HashSet<char> digits = new HashSet<char>();
        foreach (char c in number.ToString())
        {
            if (c == '0' || c > numberOfDigitsAsChar)
            {
                return false;
            }
            digits.Add(c);
        }
        return digits.Count == numberOfDigits;
    }

    public static bool CheckIsTenPandigital(long number)
    {
        if (number < 1_000_000_000 || number > 9_999_999_999)
        {
            return false;
        }

        HashSet<char> digits = new HashSet<char>();
        foreach (char c in number.ToString())
        {
            if (! digits.Add(c))
            {
                return false;
            }
        }
        return true;
    }
}

