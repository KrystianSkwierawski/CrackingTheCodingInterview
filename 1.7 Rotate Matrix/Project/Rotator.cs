using Force.DeepCloner;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Project;

public class Rotator : IRotator
{
    readonly private int[][] _image;
    private int[][] _tempImage;

    public Rotator(int[][] image)
    {
        _image = image ?? throw new ArgumentNullException();
        _tempImage = image.DeepClone();
    }

    public Array[] Rotate90Degrees()
    {
        int[][] o_result = _image.DeepClone();

        while (_tempImage.Length > 1)
        {
            int n = _tempImage.Length;

            IList<int> top = _tempImage.First().ToList();
            IList<int> bottom = _tempImage.Last().ToList();
            IList<int> left = new List<int>();
            IList<int> right = new List<int>();

            for (int j = 0; j < _tempImage.Length; j++)
            {
                int rightElement = _tempImage[j].Last();
                right.Add(rightElement);

                int leftElement = _tempImage[j].First();
                left.Add(leftElement);
            }

            var edgesValuesToRemove = top.Concat(bottom).Concat(left).Concat(right);
            RemoveEdgesFromTempArray(edgesValuesToRemove);

            ReplaceEdgesValues(o_result, top, right, bottom, left, n);
        }

        return o_result;
    }

    private void ReplaceEdgesValues(int[][] o_result, IList<int> top, IList<int> right, IList<int> bottom, IList<int> left, int n)
    {
        for (int row = 0; row < o_result.Length; row++)
        {
            for (int column = 0; column < n; column++)
            {
                int? topIndex = _image[row].Select((value, index) => (value, (int?)index))
                    .SingleOrDefault(x => x.value == top[column]).Item2;

                if (topIndex is not null)
                    o_result[row][(int)topIndex] = left.Reverse().ToArray()[column];



                int? rightIndex = _image[row].Select((value, index) => (value, (int?)index))
                    .SingleOrDefault(x => x.value == right[column]).Item2;

                if (rightIndex is not null)
                    o_result[row][(int)rightIndex] = top[column];



                int? bottomIndex = _image[row].Select((value, index) => (value, (int?)index))
                   .SingleOrDefault(x => x.value == bottom[column]).Item2;

                if (bottomIndex is not null)
                    o_result[row][(int)bottomIndex] = right.Reverse().ToArray()[column];



                int? leftIndex = _image[row].Select((value, index) => (value, (int?)index))
                   .FirstOrDefault(x => x.value == left[column]).Item2;

                if (leftIndex is not null)
                    o_result[row][(int)leftIndex] = bottom[column];
            }
        }
    }

    private void RemoveEdgesFromTempArray(IEnumerable<int> allValuesToRemove)
    {
        for (int row = 0; row < _tempImage.Length; row++)
        {
            foreach (var valueToRemove in allValuesToRemove)
            {
                _tempImage[row] = _tempImage[row].Where(x => x != valueToRemove).ToArray();
            }
        }

        _tempImage = _tempImage.Where(x => x.Length != 0).ToArray();
    }
}


