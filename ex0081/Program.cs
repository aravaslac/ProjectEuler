using ex0081;

internal class Program
{
    private static void Main(string[] args)
    {
        var pyramid = Pyramid.BuildPyramid();
        Console.WriteLine(pyramid);
        for (int i = pyramid.Count - 2; i > -1; i--)
        {
            for (int j = 0; j < i + 1; j++)
            {
                if (pyramid [i+1][j+1] == 0 || (pyramid[i + 1][j] < pyramid[i + 1][j + 1] && pyramid[i + 1][j] != 0))
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