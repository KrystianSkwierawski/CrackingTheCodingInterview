using System;
using System.Collections.Generic;

namespace Project;

public class MyStack
{
    public class StackNode<T>
    {
        public T Value { get; private set; }
        public StackNode<T> Next { get; set; }

        public StackNode(T value)
        {
            Value = value;
        }
    }


    Stack<int> _minValues = new();

    private StackNode<int> _top;

    public MyStack(IEnumerable<int> list)
    {
        foreach (var item in list)
        {
            Push(item);
        }
    }

    public MyStack()
    {

    }

    public int Pop()
    {
        if (_top is null)
            throw new Exception();

        int item = _top.Value;

        _top = _top.Next;

        if (item == _minValues.Peek())
            _minValues.Pop();

        return item;
    }

    public void Push(int item)
    {
        StackNode<int> t = new(item);
        t.Next = _top;
        _top = t;

        if (_minValues.Count == 0 || item < _minValues.Peek())
            _minValues.Push(item);
    }

    public int Peek()
    {
        if (_top is null)
            throw new Exception();

        return _top.Value;
    }

    public int Min()
    {
        if (_top is null)
            throw new Exception();

        return _minValues.Peek();
    }

    public bool IsEmpty()
    {
        return _top is null;
    }
}

