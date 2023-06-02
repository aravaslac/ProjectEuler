using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class PrimeFactorization
{
    private static readonly int[] _primes = Sieve.Primes(100);

    public static List<int> Factorize(int number)
    {
        if (_primes.Contains(number))
        {
            return new List<int> { number };
        }

        List<int> factors = new List<int>();

        int i = 0;
        while (number > 1)
        {
            if (number % _primes[i] == 0)
            {
                factors.Add(_primes[i]);
                number /= _primes[i];
            }
            else
            {
                i++;
            }
        }
        return factors;
    }
}
