using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex0076;

public class Decomposition
{
    List<List<int>> _decomposition;
    List<List<int>> _iteration;

    public Decomposition(int number)
    {
        _decomposition = new List<List<int>>();
        _iteration = new List<List<int>> { new List<int> { number } };
    }

    public List<List<int>> GetDecomposition()
    {
        bool skipFirst = true;
        while (_iteration.Count > 0 )
        {

            if (skipFirst)
            {
                skipFirst = false;
            }
            else
            {
                int currentSize = _decomposition.Count;
                Console.WriteLine($"Current size: {currentSize}");
                var latestAddition = _decomposition[currentSize - 1];
                Console.Write("Last addition: ");
                foreach (var item in latestAddition)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            

            List<List<int>> newIteration = new List<List<int>>();
            foreach (var list in _iteration)
            {
                int currentMax = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == 1 || list[i] <= currentMax)
                    {
                        continue;
                    }
                    
                    currentMax = list[i];                
                    
                    var pairs = Split(list[i]);
                    foreach (var pair in pairs)
                    {
                        List<int> candidate = list.ToList();
                        candidate.RemoveAt(i);
                        foreach (int j in pair)
                        {
                            candidate.Add(j);
                        }
                        candidate.Sort();

                        if (tryAddDecomposition(candidate))
                        {
                            newIteration.Add(candidate);
                        }
                    }
                }
            }
            _iteration = newIteration.ToList();
        }
        return _decomposition;
    }

    private List<List<int>> Split(int number)
    {
        List<List<int>> pairs = new List<List<int>>();
        for (int i = 1; i <= (number/2); i++)
        {
            pairs.Add(new List<int> { number - i, i});
        }
        return pairs;
    }

    private bool tryAddDecomposition(List<int> candidate)
    {
        foreach (var element in _decomposition)
        {
            if (element.SequenceEqual(candidate))
            {
                return false;
            }
        }
        _decomposition.Add(candidate);
        return true;
    }


}


