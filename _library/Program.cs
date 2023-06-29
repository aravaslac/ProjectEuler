using System;
using System.Collections.Generic;
using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] primes = Sieve.GetPrimes(1_000_000);
        Console.Write('a');
    }
}