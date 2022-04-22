using System;
using System.Collections.Generic;
using System.Linq;

namespace Project;

public class MyStack<T>
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

    public IList<T> List { get; private set; } = new List<T>();

    private StackNode<T> _top;

    public T Pop()
    {
        if (_top is null)
            throw new Exception();

        T item = _top.Value;

        _top = _top.Next;

        List.Remove(item);

        return item;
    }

    public void Push(T item)
    {
        StackNode<T> t = new(item);
        t.Next = _top;
        _top = t;

        List.Add(item);
    }

    public T Peek()
    {
        if (_top is null)
            throw new Exception();
        
        return _top.Value;
    }

    public T Min()
    {
        if (List is null)
            throw new Exception();

        return List.Min();
    }

    public bool IsEmpty()
    {
        return _top is null;
    }
}

