internal class Program
{
    private static void Main(string[] args)
    {
        long[] pentagonalNumbers = _library.FigurateNumbers.GetLongPentagonalNumbers(10000);
        long minDifference = long.MaxValue;
        for (int i = 1; i < 10000;  i++)
        {
            long firstNumber = pentagonalNumbers[i];
            for (int j = 0; j < i; j++)
            {
                long secondNumber = pentagonalNumbers[j];
                long difference = Math.Abs(secondNumber - firstNumber);
                if (! pentagonalNumbers.Contains(difference))
                {
                    continue;
                }
                long sum = firstNumber + secondNumber;
                if (! pentagonalNumbers.Contains(sum) )
                {
                    continue;
                }

                Console.WriteLine($"{firstNumber} and {secondNumber}; diff = {difference}");
                if ( difference < minDifference )
                {
                    minDifference = difference;
                }
            }
        }
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine(minDifference);
    }
}