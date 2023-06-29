using System.Collections.Generic;

namespace _library;

public static class FigurateNumbers
{

    //Returns every triangle number between lowerLimit and upperLimit (inclusive)
    public static int[] GetTriangleNumbers(int lowerLimit, int upperLimit)
    {
        List<int> triangleNumbers = new List<int>();
        int i = 1;
        int number = 1;
        while (number <= upperLimit)
        {
            if (number >= lowerLimit)
            {
                triangleNumbers.Add(number);
            }
            i++;
            number += i;
        }
        return triangleNumbers.ToArray();
    }

    //Returns every square number between lowerLimit and upperLimit (inclusive)
    public static int[] GetSquareNumbers(int lowerLimit, int upperLimit)
    {
        List<int> squareNumbers = new List<int>();
        int i = 1;
        int number = 1;
        while (number <= upperLimit)
        {
            if (number >= lowerLimit)
            {
                squareNumbers.Add(number);
            }
            i++;
            number = i * i;
        }
        return squareNumbers.ToArray();
    }

    //Returns every pentagonal number between lowerLimit and upperLimit (inclusive)
    public static int[] GetPentagonalNumbers(int lowerLimit, int upperLimit)
    {
        List<int> pentagonalNumbers = new List<int>();
        int current = 5;
        int previous = 1;

        while (current <= upperLimit)
        {
            if (current >= lowerLimit)
            {
                pentagonalNumbers.Add(current);
            }
            int next = 2 * current - previous + 3;
            previous = current;
            current = next;
        }
        
        return pentagonalNumbers.ToArray();
    }

    //Returns every hexagonal number between lowerLimit and upperLimit (inclusive)
    public static int[] GetHexagonalNumbers(int lowerLimit, int upperLimit)
    {
        List<int> hexagonalNumbers = new List<int>();
        int i = 1;
        int number = 1;
        while (number <= upperLimit)
        {
            if (number >= lowerLimit)
            {
                hexagonalNumbers.Add(number);
            }
            i++;
            number = (2*i - 1) * i;
        }
        return hexagonalNumbers.ToArray();
    }

    //Returns every heptagonal number between lowerLimit and upperLimit (inclusive)
    public static int[] GetHeptagonalNumbers(int lowerLimit, int upperLimit)
    {
        List<int> heptagonalNumbers = new List<int>();
        int i = 1;
        int number = 1;
        while (number <= upperLimit)
        {
            if (number >= lowerLimit)
            {
                heptagonalNumbers.Add(number);
            }
            i++;
            number = (5 * i * i - 3 * i) / 2;
        }
        return heptagonalNumbers.ToArray();
    }

    //Returns every octagonal number between lowerLimit and upperLimit (inclusive)
    public static int[] GetOctagonalNumbers(int lowerLimit, int upperLimit)
    {
        List<int> octagonalNumbers = new List<int>();
        int i = 1;
        int number = 1;
        while (number <= upperLimit)
        {
            if (number >= lowerLimit)
            {
                octagonalNumbers.Add(number);
            }
            i++;
            number = (3 * i - 2) * i;
        }
        return octagonalNumbers.ToArray();
    }


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
