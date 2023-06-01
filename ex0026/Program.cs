internal class Program
{
    private static void Main(string[] args)
    {
        for (int denominator = 2; denominator < 1000; denominator++)
        {
            //test for terminating decimal
            int remainder = denominator;
            while (remainder > 1)
            {
                int testNumber = remainder;
                if (remainder % 2 == 0)
                {
                    remainder /= 2;
                }
                if (remainder % 5 == 0)
                {
                    remainder /= 5;
                }
                if (remainder == testNumber)
                {
                    break;
                }
            }
            if (remainder == 1)
            {
                continue;
            }


            //https://oeis.org/A001913

        }
    }
}