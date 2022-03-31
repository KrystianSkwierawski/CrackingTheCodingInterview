using Force.DeepCloner;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project;

public class Matrix : IMatrix
{
    public int[][] SetZeros(int[][] image)
    {
        if (image is null || image.Length == 0)
            throw new ArgumentNullException();

        int[][] o_result = image.DeepClone();

        for (int row = 0; row < image.Length; row++)
        {
            var zerosInCurrentRow = image[row].Select((value, index) => (value, index)).Where(x => x.value == 0);

            if (zerosInCurrentRow.Count() == 0)
                continue;

            SetRow(o_result, row);
            SetColumns(o_result, zerosInCurrentRow);
        }

        return o_result;
    }

    private void SetRow(int[][] o_reuslt, int row)
    {
        for (int column = 0; column < o_reuslt[row].Length; column++)
        {
            o_reuslt[row][column] = 0;
        }
    }

    private void SetColumns(int[][] o_result, IEnumerable<(int value, int index)> zerosInCurrentRow)
    {
        foreach (var zero in zerosInCurrentRow)
        {
            for (int row = 0; row < o_result.Length; row++)
            {
                o_result[row][zero.index] = 0;
            }
        }
    }
}

