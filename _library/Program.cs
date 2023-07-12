using System;
using System.Collections.Generic;
using _library;

internal class Program
{
    private static void Main(string[] args)
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.Write("-");
        }
        for (int i = 0; i < 1000; i++)
        {
            Console.Write("\b \b");
        }
    }
}