using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _library
{
    public static class Totient
    {
        /// <summary>
        /// Returns the value of Euler's totient function for a given positive integer n.
        /// </summary>
        public static int GetTotientValue(int n)
        {
            if (n < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            Dictionary<int,int> factors = PrimeFactorization.FactorizeWithPowers(n);
            
            if (factors.Keys.Count == 1 && factors.Keys.Contains(n)) // n is prime
            {
                return n - 1;
            }

            int phi = 1;
            foreach (int prime in factors.Keys)
            {
                phi *= prime - 1;
                for (int i = 1; i < factors[prime]; i++)
                {
                    phi *= prime;
                }
            }
            return phi;            
        }

        /// <summary>
        /// Gets the sum of every value of Euler's totient function up to the given n
        /// </summary>
        public static BigInteger GetTotientSum (int n)
        {
            if (n < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            BigInteger sum = 0;
            int index = 0;
            while (index < n)
            {
                index++;
                sum += GetTotientValue(index);
            }
            return sum;
        }
    }
}
