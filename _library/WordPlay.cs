using System.Collections.Generic;

namespace _library;

public class WordPlay
{
    private static readonly Dictionary<char, int> _letterValues = new Dictionary<char, int>();

    static WordPlay()
    {
        int i = 1;
        for (char a = 'A'; a <= 'Z'; a++)
        {
            _letterValues.Add(a, i);
            i++;
        }
    }
    
public static int GetWordValue(string word)
    {
        word = word.ToUpper();
        int value = 0;
        foreach(char letter in word)
        {
            value += _letterValues[letter];
        }
        return value;
    }
}