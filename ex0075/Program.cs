using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        // Using Euclid's formula for generating Pythagorean triples.
        // a = k*(m² - n²)
        // b = k*(2mn)
        // c = k*(m² + n²)
        // m > n > 0 and with m and n coprime and not both odd
        // Since it's a right triangle, b and c are guaranteed to be < length/2
        const long MAX_LENGTH = 1_500_000;

        Dictionary<long, int> tripletsInEachLength = new Dictionary<long, int>();

        for (long m = 2; m <= MAX_LENGTH/4; m++)
        {
            if (m % 1_000 == 0)
            {
                Console.WriteLine($"Milestone: m = {m}");
            }
            HashSet<int> factors = PrimeFactorization.GetUniqueFactors((int)m);
            for (long n = 1; n < m; n++)
            {
                if ((m * n) % 2 == 1)
                {
                    continue;
                }
                bool badCandidate = false;
                foreach (int factor in factors)
                {
                    if (n % factor == 0)
                    {
                        badCandidate = true;
                        break;
                    }
                }
                if (badCandidate)
                {
                    continue;
                }

                int k = 1;
                while(true)
                {
                    long a = k * (m * m - n * n);
                    long b = 2 * k * m * n;
                    long c = k*(m * m + n * n);
                    long length = a + b + c;
                    if (length > MAX_LENGTH)
                    {
                        break;
                    }
                    k++;
                    if (!tripletsInEachLength.ContainsKey(length))
                    {
                        tripletsInEachLength[length] = 0;
                    }
                    tripletsInEachLength[length]++;
                }
            }
        }
        int answer = 0;
        foreach (long key in tripletsInEachLength.Keys)
        {
            if (tripletsInEachLength[key] == 1)
            {
                answer++;
            }
        }
        Console.WriteLine();
        Console.WriteLine("------------------");
        Console.WriteLine(answer);
    }
}