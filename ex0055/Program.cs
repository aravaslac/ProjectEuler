using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        int lychrelCount = 0;
        for (int i = 1; i < 10000; i++)
        {
            bool isLychrel = true;
            BigInteger number = i;
            for (int iteration = 0; iteration < 50;  iteration++)
            {
                string numberAsString = number.ToString();
                string reverse = _library.StringReversal.Reverse(numberAsString);
                BigInteger sum = number + BigInteger.Parse(reverse);
                if (_library.StringReversal.CheckIsPalindrome(sum.ToString()))
                {
                    isLychrel = false;
                    break;
                }
                number = sum;
            }
            if (isLychrel)
            {
                lychrelCount++;
                Console.WriteLine(i);
            }
        }
        Console.WriteLine("------------------------");
        Console.WriteLine(lychrelCount);
    }
}