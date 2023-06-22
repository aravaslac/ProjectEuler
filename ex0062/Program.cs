using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        BigInteger natural = 0;
        int numberOfDigits = 0;
        List<List<int[]>> digitFamilies = new List<List<int[]>>();
        List<int[]> winningFamily = new List<int[]>();
        BigInteger winningMember = 0;
        bool notFound = true;
        while (notFound)
        {
            natural++;
            BigInteger cube = natural * natural * natural;
            Console.WriteLine($"{natural}^3 = {cube}");
            int[] digits = _library.DigitOperations.GetDigitsAsInts(cube);
            if (digits.Length != numberOfDigits)
            {
                digitFamilies = new List<List<int[]>>();
                numberOfDigits = digits.Length;
            }
            bool newFamily = true;
            foreach (var family in digitFamilies)
            {
                if (_library.Permutation.CheckPermutation(digits, family[0]))
                {
                    family.Add(digits);
                    newFamily = false;
                    if (family.Count == 5)
                    {
                        notFound = false;
                        winningFamily = family.ToList();
                        winningMember = cube;
                    }
                    break;
                }
            }
            if (newFamily)
            {
                digitFamilies.Add(new List<int[]> { digits });
            }
        }
        BigInteger minimum = winningMember;
        foreach (int[] member in winningFamily)
        {
            BigInteger number = 0;
            foreach (int digit in member)
            {
                number *= 10;
                number += digit;
            }
            if (number < minimum)
            {
                minimum = number;
            }
        }

        Console.WriteLine("-------------------------");
        Console.WriteLine(minimum);
    }
}