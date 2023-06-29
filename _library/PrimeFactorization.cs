using System;
using System.Collections.Generic;
using System.Linq;

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

    public static List<int> Factorize(int inputNumber, int[] listOfPrimes)
    {
        List<int> factors = new List<int>();
        int number = inputNumber;
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
            if (i == outOfBounds || listOfPrimes[i] * 2 > inputNumber) //number is prime
            {
                factors.Add(number);
                return factors;
            }
        }
        return factors;
    }

    /// <summary>
    /// Gets the prime factors of a number, returning a dictionary with the factors as the keys and their powers as values.
    /// </summary>
    public static Dictionary<int, int> FactorizeWithPowers(int inputNumber)
    {
        Dictionary<int, int> factors = new Dictionary<int, int>();
        int[] listOfPrimes = Sieve.GetQuickPrimes((int)Math.Sqrt(inputNumber));
        int number = inputNumber;
        int outOfBounds = listOfPrimes.Length;
        int i = 0;
        while (number > 1)
        {
            int prime = listOfPrimes[i];
            if (number % prime == 0)
            {
                if (factors.ContainsKey(prime))
                {
                    factors[prime]++;
                }
                else
                {
                    factors[prime] = 1;
                }
                number /= prime;
            }
            else
            {
                i++;
            }
            if (i == outOfBounds || prime * 2 > inputNumber) //number is prime
            {
                factors[number] = 1;
                return factors;
            }
        }
        return factors;
    }

    /// <summary>
    /// Gets the prime factors of a number, returning a dictionary with the factors as the keys and their powers as values. Takes a list of primes as input.
    /// </summary>
    public static Dictionary<int, int> FactorizeWithPowers(int inputNumber, int[] listOfPrimes)
    {
        Dictionary<int,int> factors = new Dictionary<int, int>();

        int number = inputNumber;
        int outOfBounds = listOfPrimes.Length;
        int i = 0;
        while (number > 1)
        {
            int prime = listOfPrimes[i];
            if (number % prime == 0)
            {
                if (factors.ContainsKey(prime))
                {
                    factors[prime]++;
                }
                else
                {
                    factors[prime] = 1;
                }
                number /= prime;
            }
            else
            {
                i++;
            }
            if (i == outOfBounds || prime * 2 > inputNumber) //number is prime
            {
                factors[number] = 1;
                return factors;
            }
        }
        return factors;
    }

    public static HashSet<int> GetUniqueFactors(int number, int[] listOfPrimes)
    {
        HashSet<int> factors = new HashSet<int>();

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
            if (i == outOfBounds || listOfPrimes[i] * 2 > number) //number is prime
            {
                factors.Add(number);
                return factors;
            }
        }
        return factors;
    }

    public static bool CheckPrimalityViaFactorization(int number)
    {
        int[] listOfPrimes = Sieve.GetQuickPrimes(number);
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

    public static bool CheckPrimalityViaFactorization(long number)
    {
        int[] listOfPrimes = Sieve.GetQuickPrimes((int)Math.Sqrt(number));
        int index = 0;
        long prime = listOfPrimes[index];
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

    public static bool CheckPrimalityViaFactorization(long number, int[] listOfPrimes)
    {
        int index = 0;
        long prime = listOfPrimes[index];
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
