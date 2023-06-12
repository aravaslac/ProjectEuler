using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ex0004
{
    public static class Palindrome
    {
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static int Find()
        {
            var palindromes = new List<int>();
            for (int i = 1; i < 1000; i++)
            {
                for (int j = 1; j < 1000; j++)
                {
                    int product = i * j;
                    string productText = $"{product}";
                    string reverseProduct = Reverse(productText);
                    if (reverseProduct == productText)
                    {
                        palindromes.Add(product);
                    }
                }
            }
            return palindromes.Max();
        }
    }
}
