using System;
using System.Linq;

namespace Project;

public class ThreeInOne : IThreeInOne
{
    private int[][] _stackArray = new int[3][];

    public ThreeInOne(int[] stack1, int[] stack2, int[] stack3)
    {
        _stackArray[0] = stack1 ?? Array.Empty<int>();
        _stackArray[1] = stack2 ?? Array.Empty<int>(); 
        _stackArray[2] = stack3 ?? Array.Empty<int>();
    }

    public ThreeInOne()
    {

    }

    public int Pop(int stackIndex)
    {
        if (IsEmpty(stackIndex))
            throw new Exception();

        int[] currentStack = _stackArray[stackIndex];

        int lastItem = currentStack.Last();

        currentStack = currentStack.SkipLast(1).ToArray();

        return lastItem;
    }

    public int Push(int stackIndex, int item)
    {
        int[] currentStack = _stackArray[stackIndex];

        int lastIndex = currentStack.Length;

        Array.Resize(ref currentStack, lastIndex + 1);

        currentStack[lastIndex] = item;

        return currentStack.Length;
    }

    public int Peek(int stackIndex)
    {
        if (IsEmpty(stackIndex))
            throw new Exception();

        return _stackArray[stackIndex].Last();
    }

    public bool IsEmpty(int stackIndex)
    {
        return _stackArray[stackIndex].Length == 0;
    }
}

