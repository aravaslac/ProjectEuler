using _library;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Fraction anchor = new Fraction(3, 7);
        Fraction bestCandidate = new Fraction(0, 1);

        for (int denominator = 2; denominator <= 1_000_000; denominator++)
        {
            int maxNumerator = (int) ((long)anchor.GetNumerator() * (long)denominator / (long)anchor.GetDenominator());
            if (anchor.CompareTo(new Fraction(maxNumerator, denominator)) == 0)
            {
                maxNumerator--;
            }  

            int minNumerator = (int) (1 + (long)bestCandidate.GetNumerator() * (long)denominator / (long)bestCandidate.GetDenominator());

            for (int numerator = minNumerator; numerator <= maxNumerator; numerator++)
            {
                Fraction candidate = new Fraction(numerator, denominator);
                if (candidate.CompareTo(bestCandidate) > 0)
                {
                    bestCandidate = candidate;
                }
            }
        }
        Console.WriteLine(bestCandidate.Simplify());
    }
}