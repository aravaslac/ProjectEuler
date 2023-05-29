internal class Program
{
    private static void Main(string[] args)
    {

        string[] parsedFile = File.ReadAllLines(@"D:\Programacao\csharp\ProjectEuler\ex0067\0067_triangle.txt");

        List<long> numbers = new List<long>();
        foreach (string line in parsedFile)
        {
            string[] splitLine = line.Split(' ');
            foreach (string piece in splitLine)
            {
                numbers.Add(long.Parse(piece));
            }
        }

        List<List<long>> pyramid = new List<List<long>>();
        int rowNumber = 0;
        while (numbers.Any())
        {
            List<long> row = new List<long>();
            for (int i = 0; i < rowNumber + 1; i++)
            {
                row.Add(numbers[0]);
                numbers.RemoveAt(0);
            }
            pyramid.Add(row);
            rowNumber++;
        }

        for (int i = rowNumber - 2; i > -1; i--)
        {
            for (int j = 0; j < i + 1; j++)
            {
                if (pyramid[i + 1][j] > pyramid[i + 1][j + 1])
                {
                    pyramid[i][j] += pyramid[i + 1][j];
                }
                else
                {
                    pyramid[i][j] += pyramid[i + 1][j + 1];
                }

            }
        }
        Console.WriteLine(pyramid[0][0]);

    }

}



