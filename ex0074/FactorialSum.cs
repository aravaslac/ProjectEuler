using _library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ex0074;

public static class FactorialSum
{
    static Dictionary<int, int> _digitFactorials = DigitOperations.GetDigitFactorials();

    public static BigInteger GetSum(BigInteger n)
    {
        int[] digits = DigitOperations.GetDigitsAsInts(n);
        BigInteger sum = 0;
        foreach (int digit in digits)
        {
            sum += _digitFactorials[digit];
        }
        return sum;
    }
}
