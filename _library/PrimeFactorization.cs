using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _library;
public static class PrimeFactorization
{

    public static List<int> Factorize(int number)
    {
        var primes = Sieve.GetPrimes(10000);
        if (primes.Contains(number))
        {
            return new List<int> { number };
        }

        List<int> factors = new List<int>();

        int i = 0;
        while (number > 1)
        {
            if (number % primes[i] == 0)
            {
                factors.Add(primes[i]);
                number /= primes[i];
            }
            else
            {
                i++;
            }
        }
        return factors;
    }

    public static List<int> Factorize(int number, int[] listOfPrimes)
    {
        List<int> factors = new List<int>();

        int outOfBounds = listOfPrimes.Length;
        int i = 0;
        while (number > 1)
        {
            if (number % listOfPrimes[i] == 0)
            {
                factors.Add(listOfPrimes[i]);
                number /= listOfPrimes[i];
            }
            else
            {
                i++;
            }
            if (i == outOfBounds || listOfPrimes[i] * listOfPrimes[i] > number) //number is prime
            {
                factors.Add(number);
                return factors;
            }
        }
        return factors;
    }

    public static bool CheckPrimalityViaFactorization(int number, int[] listOfPrimes)
    {
        int index = 0;
        int prime = listOfPrimes[index];
        while (prime * prime < number)
        {
            if ((number % prime) == 0)
            {
                return false;
            }
            index++;
            prime = listOfPrimes[index];
        }
        return true;
    }
}
