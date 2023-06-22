using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex0061;

public static class Cyclic
{
    public static bool IsCyclic(int[] family)
    {
        if ((int)(family[0] / 100) != family[5] % 100)
        {
            return false;
        }
        for (int i = 0; i < 5; i++)
        {
            if (family[i] % 100 != (int)(family[i+1] / 100))
            {
                return false;
            }
        }
        return true;
    }
}
