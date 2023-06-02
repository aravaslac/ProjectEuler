using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Digits
{
    public static int[] ToDigits(int number)
    {
        List<int> digits = new();
        while (number > 0)
        {
            digits.Insert(0, number % 10);
            number = (int)(number / 10);
        }
        return digits.ToArray();
    }
}
