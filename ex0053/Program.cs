internal class Program
{
    private static void Main(string[] args)
    {
        List<long> previousRow = new List<long> { 1, 3, 3, 1};
        int valuesThatExploded = 0;
        for (int rowNumber = 4; rowNumber <= 100;  rowNumber++)
        {
            Console.WriteLine($"Current Row: {rowNumber}");
            List<long> currentRow = new List<long> { 1, rowNumber};
            for (int i = 2; i < rowNumber - 1; i++)
            {
                long firstNumber = previousRow[i - 1];
                long secondNumber = previousRow[i];
                if (firstNumber == -1 || secondNumber == -1)
                {
                    currentRow.Add(-1);
                    valuesThatExploded++;
                    continue;
                }
                long nextNumber = firstNumber + secondNumber;
                if (nextNumber > 1_000_000)
                {
                    currentRow.Add(-1);
                    valuesThatExploded++;
                    continue;
                }
                currentRow.Add(nextNumber);
            }
            currentRow.Add(rowNumber);
            currentRow.Add(1);

            previousRow = currentRow;
        }
        Console.WriteLine("----------------");
        Console.WriteLine(valuesThatExploded);
    }
}