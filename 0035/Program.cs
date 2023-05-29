using _0035;

internal class Program
{
    private static void Main(string[] args)
    {
        int count = 13;
        List<int> primes = Sieve.Primes(1_000_000).ToList();

        List<int> primesUpdated = primes.ToList();
        foreach (int prime in primes)
        {
            if (prime < 100)
            {
                primesUpdated.Remove(prime);
            }
            
        }

        var evenDigits = new List<int>
        {
            0, 2, 4, 6,8
        };

        foreach (int prime in primesUpdated)
        {   
            var digits = new List<int>();
            int number = prime;
            while (number > 0)
            {
                digits.Add(number % 10);
                number /= 10;
            }
       
            
            bool hasEvenDigit = false;
            foreach (int digit in digits)
            {
                if (evenDigits.Contains(digit))
                {
                    hasEvenDigit = true;
                    break;
                }
            }
            if (hasEvenDigit)
            {
                continue;
            }

            digits.Reverse();

            var permutations = new List<List<int>>()
            {
                digits
            };

            for (int i = 0; i < digits.Count - 1; i++)
            {
                var permutation = DigitShifter.ShiftLeft(permutations[i]);
                permutations.Add(permutation);
            }


            bool isCircular = true;
            for (int j = 1; j < digits.Count - 1; j++)
            {
                int permutationInt = 0;
                foreach (int digit in permutations[j])
                {
                    permutationInt *= 10;
                    permutationInt += digit;
                }
                Console.Write($"{permutationInt} ");
                if (! primesUpdated.Contains(permutationInt))
                {
                    isCircular = false;
                    break;
                }
            }
            Console.WriteLine();
            if (isCircular)
            {
                count++;
            }
            Console.WriteLine(count);
        }
        Console.WriteLine(count);
        Console.ReadLine();
    }
}


