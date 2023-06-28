using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> seed = new List<string>();
        for (int i = 1; i <= 10;  i++)
        {
            seed.Add(i.ToString());
        }
        var permutations = _library.Permutation.GetPermutations(seed.ToArray());
        Console.WriteLine("Finished permutations");
        Console.WriteLine("---------------------");
        //indexes are determined according to positions.png
        //16-digit string means 10 can only appear once, so its index is equal to or greater than 5.

        int highestArrayLead = 0;
        BigInteger highestValue = 0;
        foreach (var permutation in permutations)
        {
            if (Array.IndexOf(permutation, "10") < 5)
            {
                continue;
            }
            var groups = new List<string[]>();

            bool validGroup = true;
            int baseSum = 0;
            string lowestGroupLead = "11";
            int lowestGroupIndex = 0;
            for (int i = 0; i < 5; i++)
            {
                string a = permutation[i + 5];
                int aInt = int.Parse(a);
                if (aInt < highestArrayLead)
                {
                    validGroup = false;
                    break;
                }
                string b = permutation[i];
                string c = permutation[(i+1) % 5];

                int sum = aInt + int.Parse(b) + int.Parse(c);

                if (i == 0)
                {
                    baseSum = sum;
                }
                else
                {
                    if (sum != baseSum)
                    {
                        validGroup = false;
                        break;
                    }
                }

                if (aInt < int.Parse(lowestGroupLead))
                {
                    lowestGroupLead = a;
                    lowestGroupIndex = i;
                }

                var group = new string[3]
                {
                    a, b, c
                };
                groups.Add(group);
            }

            if (!validGroup)
            {
                continue;
            }

            var sortedGroups = _library.ListOperations.LeftShift(groups, lowestGroupIndex);
            string groupArray = "";
            foreach ( var group in sortedGroups )
            {
                foreach ( var a in group )
                {
                    groupArray += a;
                }
            }
            bool winner = false;
            int firstDigit = int.Parse(lowestGroupLead.Substring(0, 1));
            var finalValue = BigInteger.Parse(groupArray);
            if (firstDigit > highestArrayLead)
            {
                highestArrayLead = firstDigit;
                winner = true;
            }
            if (winner || finalValue > highestValue)
            {
                highestValue = finalValue;
                Console.WriteLine(finalValue);
            }
        }
        Console.WriteLine("------------------------");
        Console.WriteLine(highestValue);
    }
}