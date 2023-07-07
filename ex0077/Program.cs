using ex0077;

internal class Program
{
    private static void Main(string[] args)
    {
        int i = 2;
        int maxValue = 0;
        while (maxValue <= 5000)
        {
            Decomposition decomposition = new Decomposition(i);
            int value = decomposition.GetNumberOfDecompositions();
            if (value > maxValue)
            {
                maxValue = value;
                Console.WriteLine($"{i} - {value}");
            }
            i++;
        }
    }
}
