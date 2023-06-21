using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex0060;

public static class Permutations
{
    public static long[] GetPermutations(int[] family)
    {
        List<long> permutations = new List<long>();
        foreach (int element in family)
        {
            foreach (int otherElement in family)
            {
                if (otherElement == element)
                {
                    continue;
                }
                permutations.Add(long.Parse(element.ToString() + otherElement.ToString()));
            }
        }
        return permutations.ToArray();
    }

    public static long[] GetNewPermutations(List<int> originalFamily, int newElement)
    {
        List<long> newPermutations = new List<long>();
        foreach (long element in originalFamily)
        {
            newPermutations.Add(long.Parse(element.ToString() + newElement.ToString()));
            newPermutations.Add(long.Parse(newElement.ToString() + element.ToString()));
        }
        return newPermutations.ToArray();
    }
}
