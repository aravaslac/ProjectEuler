using ex0012;
using System.Numerics;
using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = Sieve.Primes(10000000);
        BigInteger triangularNumber = 3;
        BigInteger triangularNumberIndex = 2;
        BigInteger[] candidates = new BigInteger[50];
        int candidateIndex = 0;

        while (candidateIndex < 50)
        {
            Dictionary<int, int> factors = new Dictionary<int, int> //1 is omitted for ease of calculation
            {
                {2,0}
            };
            bool goodCandidate = false;
            int i = 0;
            BigInteger number = triangularNumber;
            while (i < primes.Length)
            {
                int primeFactor = primes[i];
                if (primeFactor*primeFactor > triangularNumber)
                {
                    break;
                }
                if (number % primeFactor == 0)
                {
                    factors[primeFactor]++;
                    number /= primeFactor;
                }
                else
                {
                    i++;
                    factors.Add(primes[i], 0);
                }
                if (number == 1)
                {
                    goodCandidate = true;
                    break;
                }
            }

            if (goodCandidate)
            {
                for (int k = 2; k < factors.Count - 1; k++) 
                {
                    if (factors.ElementAt(k).Value < factors.ElementAt(k + 1).Value)
                    {
                        goodCandidate = false;
                        break;
                    }
                }
            }


            if (goodCandidate)
            {
                int numberOfDivisors = 1;
                foreach (int key in factors.Keys)
                {
                    numberOfDivisors *= factors[key]+1;
                }
                Console.WriteLine($"Number: {triangularNumber}  Number of Divisors: {numberOfDivisors}");
                Console.WriteLine();
                
                if (numberOfDivisors > 500)
                {
                    candidates[candidateIndex] = triangularNumber;
                    candidateIndex++;
                }
            }
            triangularNumberIndex ++;
            triangularNumber += triangularNumberIndex;
        }

        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine(candidates[0]);
        BigInteger minimum = candidates[0];
        for (int i = 1; i < 50; i++)
        {
            Console.WriteLine(candidates[i]);
            if (candidates[i] < minimum)
            {
                minimum = candidates[i];
            }
        }
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("The minimum value is: ");
        Console.WriteLine(minimum);
        Console.ReadLine();
    }
}

// Algumas condições a mais derivadas de https://en.wikipedia.org/wiki/Highly_composite_number :
// O número tem que ser necessariamente divisível por um dos 501 primeiros números primos.
// Sendo c1, c2, (...), ck as potências dos fatores primos do número, temos:
// c1 >= c2 >= c3 >= c4...
// (c1+1)*(c2+1)*...*(ck+1) é o número de divisores