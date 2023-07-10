using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex0081
{
    internal static class Pyramid
    {
        internal static List<List<long>> BuildPyramid()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"0081_matrix.txt");
            string[] stringRows = File.ReadAllLines(filePath);

            List<int[]> rows = new List<int[]>();
            foreach (string stringRow in stringRows)
            {
                string[] splitString = stringRow.Split(',');
                List<int> row = new List<int>();
                foreach (string piece in splitString)
                {
                    row.Add(int.Parse(piece));
                }
                rows.Add(row.ToArray());
            }
            
            int size = rows[0].Length;
            int pyramidSize = 2 * size - 1;

            List<List<long>> pyramid = new List<List<long>>();
            
            //Iterate through upper triangular matrix
            for (int i = 0; i < size; i++)
            {
                List<long> rowNumbers = new List<long>();
                for (int j = 0; j <= i; j++)
                {
                    rowNumbers.Add(rows[i - j][j]);
                }
                pyramid.Add(rowNumbers);
            }

            //Iterate through lower triangular matrix
            for (int i = 0; i < size - 1; i++)
            {
                List<long> rowNumbers = new List<long>();
                for (int j = 0; j < size - i - 1; j++)
                {
                    rowNumbers.Add(rows[size - 1 - j][j + i + 1]);
                }
                pyramid.Add(rowNumbers);
            }
            

            for (int pyramidRow = size; pyramidRow < pyramidSize; pyramidRow++)
            {
                while (pyramid[pyramidRow].Count < pyramidRow + 1)
                {
                    pyramid[pyramidRow].Add(0);
                    pyramid[pyramidRow].Insert(0, 0);
                }
            }

            return pyramid;
        }
    }
}
