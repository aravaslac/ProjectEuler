internal class Program
{
    private static void Main(string[] args)
    {
        List<int> numbers = new List<int>
        {
             75,95,64,17,47,82,18,35,87,10,20,04,82,47,65,19,01,23,75,03,34,88,02,77,73,07,63,67,99,65,04,28,06,16,70,92,41,41,26,56,83,40,80,70,33,41,48,72,33,47,32,37,16,94,29,53,71,44,65,25,43,91,52,97,51,14,70,11,33,28,77,73,17,78,39,68,17,57,91,71,52,38,17,14,91,43,58,50,27,29,48,63,66,04,68,89,53,67,30,73,16,69,87,40,31,04,62,98,27,23,09,70,98,73,93,38,53,60,04,23
        };

        List<List<int>> pyramid = new List<List<int>>();
        int rowNumber = 0;
        while (numbers.Any())
        {
            List<int> row = new List<int>();
            for (int i = 0; i < rowNumber; i++)
            {
                row.Add(numbers[0]);
                numbers.RemoveAt(0);
            }
            pyramid.Add(row);
            rowNumber++;
        }

        rowNumber--;
        int total = pyramid[0][0];
        int horizontalPosition = 0;
        for (int i = 1; i < rowNumber-1; i++)
        {
            int leftPath = 0;
            int rightPath = 0;
            for (int j = i+1; j < rowNumber; j++)
            {
                leftPath += pyramid[j][horizontalPosition];
                rightPath += pyramid[j][horizontalPosition + 1];
                if (rightPath > leftPath)
                {
                    horizontalPosition++;
                }
                Console.WriteLine(i);
                total += pyramid[i][horizontalPosition];
            }
            
        }
        int left = pyramid[rowNumber - 1][horizontalPosition];
        int right = pyramid[rowNumber - 1][horizontalPosition + 1];
        if (right > left)
        {
            horizontalPosition++;
        }
        total += pyramid[rowNumber - 1][horizontalPosition];
        Console.WriteLine(total);
        Console.WriteLine();
    }

}