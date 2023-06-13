internal class Program
{
    private static void Main(string[] args)
    {
        int digit = 1;
        int integer = 1;
        int product = 1;
        int reversedDigitIndex = 0;
        for (int d = 10; d < 1_000_001; d *= 10)
        {
            while (digit < d)
            {
                digit++;
                if (reversedDigitIndex == 0)
                {
                    integer++;
                    reversedDigitIndex = _library.DigitOperations.GetNumberOfDigits(integer) - 1;
                    continue;
                }
                reversedDigitIndex--;
            }
            string intAsString = integer.ToString();
            int importantDigit = int.Parse($"{intAsString[intAsString.Length - 1 - reversedDigitIndex]}");
            if (importantDigit == 0)
            {
                Console.WriteLine("Deu zero");
                Console.ReadLine();
                Environment.Exit(0);
            }
            product *= importantDigit;
        }
        Console.WriteLine(product);
    }
}