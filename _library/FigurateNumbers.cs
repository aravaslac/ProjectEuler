using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _library;

public static class FigurateNumbers
{
    public static int[] GetPentagonalNumbers(int quantity)
    {
        int[] numbers = new int[quantity];
        numbers[0] = 1;
        numbers[1] = 5;
        int firstPrevious = 5;
        int secondPrevious = 1;
        for (int i = 2; i < quantity; i++)
        {
            int nextNumber = 2 * firstPrevious - secondPrevious + 3;
            numbers[i] = nextNumber;
            secondPrevious = firstPrevious;
            firstPrevious = nextNumber;
        }
        return numbers;
    }

    public static long[] GetLongPentagonalNumbers(int quantity)
    {
        long[] numbers = new long[quantity];
        numbers[0] = 1;
        numbers[1] = 5;
        long firstPrevious = 5;
        long secondPrevious = 1;
        for (int i = 2; i < quantity; i++)
        {
            long nextNumber = 2 * firstPrevious - secondPrevious + 3;
            numbers[i] = nextNumber;
            secondPrevious = firstPrevious;
            firstPrevious = nextNumber;
        }
        return numbers;
    }
}
