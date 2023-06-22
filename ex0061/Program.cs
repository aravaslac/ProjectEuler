using ex0061;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int[]> figurateNumbers = new List<int[]>
        {
            _library.FigurateNumbers.GetOctagonalNumbers(1000, 9999),
            _library.FigurateNumbers.GetHeptagonalNumbers(1000, 9999),
            _library.FigurateNumbers.GetHexagonalNumbers(1000, 9999),
            _library.FigurateNumbers.GetPentagonalNumbers(1000, 9999),
            _library.FigurateNumbers.GetSquareNumbers(1000, 9999),
            _library.FigurateNumbers.GetTriangleNumbers(1000, 9999)
        };

        List<int> indexLimitBuilder = new List<int>();
        foreach (var figurateNumberFamily in figurateNumbers)
        {
            indexLimitBuilder.Add(figurateNumberFamily.Length - 1);
        }
        int[] indexLimit = indexLimitBuilder.ToArray();

        List<int> indexer = new List<int> { -1, 0, 0, 0, 0, 0 };
        int[] winner = new int[6];
        bool stillSearching = true;

        int currentFifthIndex = 0;

        while (stillSearching)
        {
            for (int indexPicker = 0; indexPicker < 6; indexPicker++)
            {
                if (indexer[indexPicker] < indexLimit[indexPicker])
                {
                    indexer[indexPicker]++;
                    break;
                }
                indexer[indexPicker] = 0;
            }

            //Anti-anxiety
            if (indexer[4] != currentFifthIndex)
            {
                currentFifthIndex = indexer[4];
                foreach (int index in indexer)
                {
                    Console.Write($"{index} ");
                }
                Console.WriteLine();
            }
            //--------------------
            
            List<int> family = new List<int>();
            bool validFamily = true;
            for (int i = 0; i < 6; i++)
            {
                int number = figurateNumbers[i][indexer[i]];
                if (family.Contains(number))
                {
                    validFamily = false;
                    break;
                }
                family.Add(figurateNumbers[i][indexer[i]]);
            }
            if (!validFamily)
            {
                continue;
            }
            bool firstTest = false;
            foreach (int member in family)
            {
                firstTest = false;
                for (int i = 0; i < 6; i++)
                {
                    if (family[i] == member)
                    {
                        continue;
                    }
                    if (member % 100 == (int)(family[i] / 100))
                    {
                        firstTest = true;
                        break;
                    }
                }
                if (!firstTest)
                {
                    break;
                }
            }
            if (!firstTest)
            {
                continue;
            }

            bool secondTest = false;
            foreach (int member in family)
            {
                secondTest = false;
                for (int i = 0; i < 6; i++)
                {
                    if (family[i] == member)
                    {
                        continue;
                    }
                    if ((int)(member / 100) == family[i] % 100)
                    {
                        secondTest = true;
                        break;
                    }
                }
                if (!secondTest)
                {
                    break;
                }
            }
            if (!secondTest)
            {
                continue;
            }

            var permutations = _library.Permutation.GetPermutations(family.ToArray());
            foreach (var permutation in permutations)
            {
                if (Cyclic.IsCyclic(permutation))
                {
                    winner = permutation;
                    stillSearching = false;
                    break;
                }
            }
        }

        Console.WriteLine("-----------------------");
        int sum = 0;
        foreach (var dude in winner)
        {
            Console.Write($"{dude} ");
            sum += dude;
        }
        Console.WriteLine();
        Console.WriteLine(sum);
    }
}