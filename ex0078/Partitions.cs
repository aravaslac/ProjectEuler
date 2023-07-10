using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ex0078;

internal class Partitions
{
    private static List<BigInteger> partitions = new List<BigInteger> { 1 };
    private static List<long> generalizedPentagonalNumbers = new List<long>();
    private static long maxPentagonal = 0;
    private static int pentagonalIndex = 1;

    private int _n;

    internal Partitions(int n)
    {
        _n = n;
        IncrementPartitionList();
    }

    public BigInteger GetPartitions()
    {
        return partitions[_n];
    }

    private void IncrementPartitionList()
    {
        if (_n >= maxPentagonal)
        {
            RaisePentagonalNumbers();
        }

        BigInteger p = 0;
        int index = 0;
        long pentagonal = generalizedPentagonalNumbers[0];
        int sign;
        while (pentagonal <= _n)
        {
            if (index % 4 == 0 || index % 4 == 1)
            {
                sign = 1;
            }
            else
            {
                sign = -1;
            }
            p += sign * partitions[_n - (int)pentagonal];
            index++;
            pentagonal = generalizedPentagonalNumbers[index];
        }
        partitions.Add(p);
    }

    private static void RaisePentagonalNumbers()
    {
        for (int i = pentagonalIndex; i < pentagonalIndex * 10; i++)
        {
            List<int> duo = new List<int> { i, -i};
            foreach (int k in duo)
            {
                generalizedPentagonalNumbers.Add(k * (3 * k - 1) / 2);
            }
        }
        maxPentagonal = generalizedPentagonalNumbers[^1];
        pentagonalIndex *= 10;
    }
}
