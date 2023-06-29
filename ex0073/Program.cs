using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        Fraction rightAnchor = new Fraction(1, 2);
        Fraction leftAnchor = new Fraction(1, 3);
        int topRight = rightAnchor.GetNumerator();
        int bottomRight = rightAnchor.GetDenominator();
        int topLeft = leftAnchor.GetNumerator();
        int bottomLeft = leftAnchor.GetDenominator();
        HashSet<Fraction> validFractions = new HashSet<Fraction>();
        for (int denominator = 2; denominator <= 12000; denominator++)
        {
            if (denominator % 1000 == 0)
            {
                Console.WriteLine($"Milestone: denominator = {denominator}");
            }

            int maxNumerator = (int)((long)topRight * denominator / bottomRight);
            if (rightAnchor.CompareTo(new Fraction(maxNumerator, denominator)) == 0)
            {
                maxNumerator--;
            }

            int minNumerator = (int)(1 + (long)topLeft * denominator / bottomLeft);

            for (int numerator = minNumerator; numerator <= maxNumerator; numerator++)
            {
                Fraction candidate = new Fraction(numerator, denominator);
                validFractions.Add(candidate.Simplify());
            }
        }
        Console.WriteLine("-------------------------");
        Console.WriteLine(validFractions.Count);
    }
}