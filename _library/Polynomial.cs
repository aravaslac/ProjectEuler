using System;
using System.Collections.Generic;
using System.Linq;

namespace _library;

//TODO: use Fraction class rather than Int, to cover more cases


/// <summary>
/// Represents a polynomial as a list of coefficients of increasing power (starting from power 0)
/// </summary>
public class Polynomial
{
    private List<int> _coefficients;

    /// <summary>
    /// Instantiates a new polynomial passing the coefficients in increasing order of power
    /// </summary>
    /// <param name="coefficientArray">Array of coefficients in increasing order of power</param>
    public Polynomial(int[] coefficientArray)
    {
        _coefficients = coefficientArray.ToList();
    }

    /// <summary>
    /// Instantiates a new cyclotomical polynomial (1-q^a)(1-q^(a-1))...(1-q^b) where b &#60; a
    /// </summary>
    /// <param name="a">Highest cyclotomical coefficient</param>
    /// <param name="b">Lowest cyclotomical coefficient</param>
    public Polynomial(int a, int b)
    {
        int maxPower = a;
        for (int i = b; i < a; i++)
        {
            maxPower += i;
        }
        
        _coefficients = new List<int>();
        for (int i = 0; i <= maxPower; i++)
        {
            _coefficients.Add(0);
        }

        _coefficients[0] = 1;
        _coefficients[a] = -1;
        for (int i = b; i < a; i++)
        {
            List<int> newCoefficients = _coefficients.ToList();
            int index = -1;
            foreach (int coefficient  in _coefficients)
            {
                index++;
                if (coefficient == 0)
                {
                    continue;
                }
                newCoefficients[index + i] += (-1) * coefficient;
            }
            _coefficients = newCoefficients.ToList();
        }
    }

    public int[] GetCoefficients()
    {
        if (_coefficients.Count == 1)
        {
            return _coefficients.ToArray();
        }

        while (_coefficients[_coefficients.Count - 1] == 0)
        {
            _coefficients.RemoveAt(_coefficients.Count - 1);
        }
        return _coefficients.ToArray();
    }

    /// <summary>
    /// Creates a deep copy of the Polynomial object
    /// </summary>
    /// <returns>The deep copy of the Polynomial object</returns>
    public Polynomial Clone()
    {
        return new Polynomial(GetCoefficients());
    }

    /// <summary>
    /// Executes the Euclidean Division on the polynomial, returning the quotient and the remainder as a tuple
    /// </summary>
    /// <param name="divisor">The divisor</param>
    /// <returns>A tuple whose first value is the quotient and second value is the remainder</returns>
    public (Polynomial, Polynomial) EuclideanDivision(Polynomial divisor)
    {
        List<int> remainder = _coefficients.ToList();
        remainder.Reverse();
        List<int> divisorCoefficients = divisor.GetCoefficients().ToList();
        divisorCoefficients.Reverse();
        int degree = divisorCoefficients.Count;
        int quotientDegree = remainder.Count - degree;
        List<int> quotientCoefficients = new List<int>();
        for (int i = 0; i <= quotientDegree; i++)
        {
            quotientCoefficients.Add(0);
        }
        while (remainder.Count >= degree)
        {
            int diff = remainder.Count - degree;
            int multiplicationFactor = remainder[0] / divisorCoefficients[0];
            quotientCoefficients[diff] = multiplicationFactor;
            for (int i = 0; i < degree; i++)
            {
                if (divisorCoefficients[i] == 0)
                {
                    continue;
                }
                remainder[i] -= multiplicationFactor * divisorCoefficients[i];
            }
            while (remainder.Count > 0 && remainder[0] == 0)
            {
                remainder.RemoveAt(0);
            }
        }
        remainder.Reverse();
        if (remainder.Count == 0)
        {
            remainder.Add(0);
        }
        Polynomial finalRemainder = new Polynomial(remainder.ToArray());
        Polynomial quotient = new Polynomial(quotientCoefficients.ToArray());
        return (quotient, finalRemainder);
    }
}
