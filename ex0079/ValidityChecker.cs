using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex0079
{
    internal static class ValidityChecker
    {
        internal static bool CheckValidity(string log, string passwordString)
        {
            int firstIndex = passwordString.IndexOf(log[0]);
            if (firstIndex == -1)
            {
                return false;
            }
            passwordString = passwordString.Substring(firstIndex + 1);

            int secondIndex = passwordString.IndexOf(log[1]);
            if (secondIndex == -1)
            {
                return false;
            }
            passwordString = passwordString.Substring(secondIndex + 1);

            return passwordString.Contains(log[2]);
        }
    }
}
