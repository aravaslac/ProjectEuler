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
}

