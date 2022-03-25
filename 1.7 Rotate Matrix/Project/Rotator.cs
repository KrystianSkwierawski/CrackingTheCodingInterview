using System;
using System.Collections.Generic;
using System.Linq;

namespace Project;

public class Rotator : IRotator
{
    public Array[] Rotate90Degrees(Array[] array)
    {
        if (array is null || array.Length == 0)
            throw new ArgumentNullException();

        List<Array> o_rotatedImageList = new();

        for (int i = 0; i < array.Length; i++)
        {
            var temp = array.ElementAtOrDefault(i + 1) == default(Array) ? array.First() : array.ElementAtOrDefault(i + 1);
            o_rotatedImageList.Add(temp);
        }

        return o_rotatedImageList.ToArray();
    }
}

