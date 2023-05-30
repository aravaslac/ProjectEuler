using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public static class ProperDivisors
    {
        public static int[] Calculate(int number)
        {
            List<int> divisors = new List<int>
            {
                1
            };
            for (int i = 2; i < number/2 + 1 ; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                }
            }
            return divisors.ToArray();
        }
    }
