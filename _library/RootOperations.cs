using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _library;

public static class RootOperations
{
    //Rationalizes fractions of the form 1/(sqrt(a) ± b).
    //Returns c, denominator of the fraction (sqrt(a) ∓ b)/c.
    public static int GetRationalizedDenominator(int a, int b)
    {
        return a - b * b;
    }
}
