internal class Program
{
    private static void Main(string[] args)
    {
        //tested for 5 digits, no good.
        List<int> primes = _library.Sieve.GetPrimes(1_000_000).ToList();
        
        while (primes[0] < 100_000)
        {
            primes.RemoveAt(0);
        }
        List<string> primesAsString = new List<string>();
        foreach (int prime  in primes)
        {
            primesAsString.Add(prime.ToString());
        }
        
        //00001 to 111111 (63) denote which digits are fixed
        Dictionary<uint, Dictionary<string,int>> fixedDigitFamilies = new Dictionary<uint, Dictionary<string,int>>();
        for (uint b = 0b_000001; b <= 0b_111111; b++)
        {
            fixedDigitFamilies[b] = new Dictionary<string,int>();
        }
                

        foreach (string prime in primesAsString)
        {
            for (uint b = 0b_000001; b <= 0b_111111; b++)
            {
                int index = 0;
                string subString = "";
                bool needRepeatingDigit = true;
                char repeatingDigit = 'a';
                bool invalidCandidate = false;
                
                foreach (char c in Convert.ToString(b, toBase: 2).PadLeft(6,'0'))
                {
                    if (c == '0')
                    {
                        if (needRepeatingDigit)
                        {
                            repeatingDigit = prime[index];
                            needRepeatingDigit = false;
                        }
                        else if (prime[index] != repeatingDigit)
                        {
                            invalidCandidate = true;
                            break;
                        }  
                    }
                    else
                    {
                        subString += prime[index];
                    }
                    index++;
                }
                if (invalidCandidate)
                {
                    continue;
                }

                if (fixedDigitFamilies[b].ContainsKey(subString))
                {
                    fixedDigitFamilies[b][subString]++;
                }
                else
                {
                    fixedDigitFamilies[b][subString] = 1;
                }
            }
        }

        uint winnerPattern = 0;
        string winnerSubstring = "";
        foreach (var familyKey in fixedDigitFamilies.Keys)
        {
            foreach (var key in fixedDigitFamilies[familyKey].Keys)
            {
                if (fixedDigitFamilies[familyKey][key] > 7)
                {
                    winnerPattern = familyKey;
                    winnerSubstring = key;
                }
            }
        }

        Console.WriteLine($"{Convert.ToString(winnerPattern, toBase: 2).PadLeft(6, '0')} - \"{winnerSubstring}\"");

        Console.WriteLine("-----------------");

        foreach (string prime in primesAsString)
        {
            if (prime[1] == '2' && prime[3] == '3' && prime[5] == '3' && prime[0] == prime[2] && prime[2] == prime[4])
            {
                Console.WriteLine(prime);
            }
        }
    }
}