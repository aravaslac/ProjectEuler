using System;

namespace _library;

public static class StringReversal
{
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static bool CheckIsPalindrome(string s)
    {
        string reverse = Reverse(s);
        return s == reverse;
    }
}
