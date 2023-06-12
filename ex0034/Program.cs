internal class Program
{
    private static void Main(string[] args)
    {
        //9!*8 is 7 digits long, so we can safely assume the ceiling to be 7 digits long.
        //So the ceiling is 9!*7 = 2540160
        
        int sum = 0;
        Dictionary<int,int> factorials = new Dictionary<int,int>
        {
            {0, 1},
            {1, 1}
        };
        for (int digit = 2; digit < 10;  digit++)
        {
            factorials.Add(digit, digit * factorials[digit - 1]);
        }

        for (int i = 3; i < 2540160; i++)
        {
            int sumOfDigitValues = 0;
            int remainder = i;
            while (remainder > 0)
            {
                sumOfDigitValues += factorials[remainder % 10];
                remainder = (int)remainder / 10;
            }
            if (sumOfDigitValues == i)
            {
                Console.WriteLine(i);
                sum += i;
            }
        }
        Console.WriteLine("------------------------");
        Console.WriteLine(sum);
    }
}