using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _library;

public static class ListOperations
{
    /// <summary>
    /// Given a list and an int, shifts the elements of the list to the left by that number of times (wrapping around).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values"></param>
    /// <param name="shift"></param>
    /// <returns></returns>
    public static List<T> LeftShift<T>(List<T> values, int shift)
    {
        int realShift = shift % values.Count;
        List<T> shiftedValues = values.ToList();
        for (int i = 0; i < realShift; i++)
        {
            shiftedValues.Add(shiftedValues[0]);
            shiftedValues.RemoveAt(0);
        }
        return shiftedValues;
    }
}
