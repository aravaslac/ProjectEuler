using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_0035
{
    public static class DigitShifter
    {
        public static List<int> ShiftLeft(List<int> digits)
        {
            var updatedList = new List<int>();
            for (int i = 0; i < digits.Count - 1; i++)
            {
                updatedList.Add(digits[i + 1]);
            }
            updatedList.Add(digits[0]);
            return updatedList;
        }
    }
}
