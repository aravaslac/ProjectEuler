internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<int, string> numberNames = new Dictionary<int, string>
        {
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
            {10, "ten"},
            {11, "eleven"},
            {12, "twelve"},
            {13, "thirteen"},
            {14, "fourteen"},
            {15, "fifteen"},
            {16, "sixteen"},
            {17, "seventeen"},
            {18, "eighteen"},
            {19, "nineteen"},
            {20, "twenty"},
            {30, "thirty"},
            {40, "forty"},
            {50, "fifty"},
            {60, "sixty"},
            {70, "seventy"},
            {80, "eighty"},
            {90, "ninety"}
        };

        for (int tens = 20; tens < 91; tens+= 10)
        {
            for (int i = 1; i < 10; i++)
            {
                numberNames.Add(tens+i, numberNames[tens] + numberNames[i]);
            }
        }

        for (int hundreds = 1; hundreds < 10; hundreds++ )
        {
            numberNames.Add(100 * hundreds, numberNames[hundreds] + "hundred");
            for (int j = 1; j < 100; j++)
            {
                numberNames.Add(100 * hundreds + j, numberNames[100 * hundreds] + "and" + numberNames[j]);
            }
        }
        numberNames.Add(1000, "onethousand");

        int letterCount = 0;
        foreach (int key in numberNames.Keys)
        {
            letterCount += numberNames[key].Length;
        }
        Console.WriteLine(letterCount);
    }
}