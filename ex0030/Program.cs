internal class Program
{
    private static void Main(string[] args)
    {
        //Through algebra, it's easy to see that all possible candidates have between 2 and 6 digits.
        int sum = 0;
        for (int i = 10; i < 1_000_000; i++)
        {
            var digits = Digits.ToDigits(i);
            int remainder = i;
            foreach (var digit in digits)
            {
                remainder -= digit * digit * digit * digit * digit;
            }

            if (remainder == 0)
            {
                sum += i;
                Console.WriteLine(i);
            }
        }
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine(sum);
    }
}