using System;
using System.Collections.Generic;

namespace Project;

public class MyStack
{
    public class StackNode<T>
    {
        public T Value { get; set; }
        public StackNode<T> Next { get; set; }

        public StackNode(T value)
        {
            Value = value;
        }
    }

    public IList<int> List
    {
        get
        {
            IList<int> o_result = new List<int>();

            StackNode<int> current = _top;
            while (current is not null)
            {
                o_result.Add(current.Value);

                current = current.Next;
            }

            return o_result;
        }
    }

    private int _length = 0;

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

        _length--;

        return item;
    }


    public void Push(int item)
    {
        StackNode<int> t = new(item);
        t.Next = _top;
        _top = t;

        _length++;
    }

    public int Peek()
    {
        if (_top is null)
            throw new Exception();

        return _top.Value;
    }
    public void Sort()
    {
        if (_top is null)
            throw new Exception();

        int temp = 0;
        StackNode<int> s1 = _top;

        while (s1.Next is not null)
        {
            StackNode<int> s2 = s1.Next;

            while(s2 is not null)
            {
                if (s1.Value > s2.Value)
                {
                    temp = s1.Value;
                    s1.Value = s2.Value;
                    s2.Value = temp;
                }

                s2 = s2.Next;
            }
       
            s1 = s1.Next;
        }
    }

    public bool IsEmpty()
    {
        return _top is null;
    }
}

