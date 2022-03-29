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

            IList<int> valuesOfTopEdge = _tempImage.First().ToList();
            IList<int> valuesOfBottomEdge = _tempImage.Last().ToList();
            IList<int> valuesOfLeftEdge = new List<int>();
            IList<int> valuesOfRightEdge = new List<int>();

            for (int j = 0; j < _tempImage.Length; j++)
            {
                int rightEdgeElement = _tempImage[j].Last();
                valuesOfRightEdge.Add(rightEdgeElement);

                int leftEdgeElement = _tempImage[j].First();
                valuesOfLeftEdge.Add(leftEdgeElement);
            }

            var edgesValuesToRemove = valuesOfTopEdge.Concat(valuesOfBottomEdge).Concat(valuesOfLeftEdge).Concat(valuesOfRightEdge);
            RemoveEdgesFromTempArray(edgesValuesToRemove);

            ReplaceEdgesValues(o_result, valuesOfTopEdge, valuesOfRightEdge, valuesOfBottomEdge, valuesOfLeftEdge, n);
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


