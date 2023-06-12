internal class Program
{
    private static void Main(string[] args)
    {
        int sum = 0;
        for (int number = 1; number < 1_000_000; number++)
        {
            if (number % 10  == 0)
            {
                continue;
            }
            string numberAsString = number.ToString();
            int reverseNumber = int.Parse(_library.StringReversal.Reverse(numberAsString));
            if (reverseNumber != number)
            {
                continue;
            }
            string binaryRepresentation = Convert.ToString(number,2);
            if (binaryRepresentation != _library.StringReversal.Reverse(binaryRepresentation))
            {
                continue;
            }
            Console.WriteLine($"{number} - {binaryRepresentation}");
            sum += number;
        }
        Console.WriteLine("--------------------------");
        Console.WriteLine(sum);
    }
}