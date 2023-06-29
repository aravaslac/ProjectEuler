using System.Collections.Generic;
using System.Linq;

namespace _library
{
    public static class Permutation
    {
        //Returns the unique permutations of an array
        public static List<T[]> GetPermutations<T>(T[] inputArray)
        {
            List<List<T>> workingSet = new List<List<T>>();
            foreach (T input in inputArray)
            {
                workingSet.Add(new List<T> { input });
            }
            for (int i = 0;  i < inputArray.Length - 1; i++)
            {
                List<List<T>> newWorkingSet = new List<List<T>>();
                foreach (var list in workingSet)
                {
                    foreach (var item in inputArray)
                    {
                        if (list.Contains(item))
                        {
                            continue;
                        }
                        List<T> newList = list.ToList();
                        newList.Add(item);
                        newWorkingSet.Add(newList);
                    }
                }
                workingSet = newWorkingSet.ToList();
            }
            List<T[]> permutations = new List<T[]>();
            foreach (var permutation in workingSet)
            {
                permutations.Add(permutation.ToArray());
            }
            return permutations;
        }

        //Check if two arrays are permutations of one another
        public static bool CheckPermutation<T>(T[] firstArray, T[] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
            {
                return false;
            }
            List<T> firstList = firstArray.ToList();
            List<T> secondList = secondArray.ToList();
            while (firstList.Count > 0)
            {
                T element = firstList[0];
                if (! secondList.Remove(element))
                {
                    return false;
                }
                firstList.RemoveAt(0);
            }
            return true;
        }
    }
}
