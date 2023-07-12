internal class Program
{
    private static void Main(string[] args)
    {
        string filePath = Path.Combine(Environment.CurrentDirectory, @"0082_matrix.txt");
        //string filePath = Path.Combine(Environment.CurrentDirectory, @"testMatrix.txt");
        string[] stringRows = File.ReadAllLines(filePath);
        int size = stringRows.Length;

        List<string[]> splitStringRows = new List<string[]>();
        foreach (string stringRow in stringRows)
        {
            splitStringRows.Add(stringRow.Split(","));
        }

        List<int[]> columns = new List<int[]>();
        for (int i = 0; i < size; i++)
        {
            List<int> column = new List<int>();
            for (int j = 0; j < size; j++)
            {
                column.Add(int.Parse(splitStringRows[j][i]));
            }
            columns.Add(column.ToArray());
        }

        for (int i = size-2; i >= 0; i--)
        {
            List<int> newColumn = new List<int>();
            for (int j = 0; j < size; j++)
            {
                int minValue = columns[i][j] + columns[i + 1][j];

                for (int k = 0; k < j; k++)
                {
                    int candidate = columns[i][j] + columns[i + 1][k];
                    if (candidate >= minValue)
                    {
                        continue;
                    }
                    bool validCandidate = true;
                    for (int diff = 0; diff < j - k; diff++)
                    {
                        candidate += columns[i][k + diff];
                        if ( candidate >= minValue)
                        {
                            validCandidate = false;
                            break;
                        }
                    }
                    if (!validCandidate)
                    {
                        continue;
                    }
                    minValue = candidate;
                }

                for (int k = j + 1; k < size; k++)
                {
                    int candidate = columns[i][j] + columns[i + 1][k];
                    if (candidate >= minValue)
                    {
                        continue;
                    }
                    bool validCandidate = true;
                    for (int diff = 0; diff < k - j; diff++)
                    {
                        candidate += columns[i][j + 1 + diff];
                        if (candidate >= minValue)
                        {
                            validCandidate = false;
                            break;
                        }
                    }
                    if (!validCandidate)
                    {
                        continue;
                    }
                    minValue = candidate;
                }

                newColumn.Add(minValue);
            }

            columns.RemoveAt(i + 1);
            columns.RemoveAt(i);
            columns.Add(newColumn.ToArray());

            //Console.WriteLine("-------------------------");
            //for (int row = 0; row < size; row++)
            //{
            //    for (int column = 0; column <= i; column++)
            //    {
            //        Console.Write($"{columns[column][row]} ");
            //    }
            //    Console.WriteLine();
            //}
        }
        int min = int.MaxValue;
        foreach (int number in columns[0])
        {
            if (number < min)
            {
                min = number;
            }
        }
        Console.WriteLine(min);
    }
}