using System;
using System.Collections.Generic;
using System.Linq;

namespace Project;

public class MyQueue<T>
{
    public IList<T> List
    {
        get
        {
            return queueOrder.List;
        }
    }

    MyStack<T> queueOrder;
    MyStack<T> stackOrder;

    public MyQueue(IEnumerable<T> list)
    {
        queueOrder = new MyStack<T>(list);
        stackOrder = new MyStack<T>(list.Reverse());
    }

    public MyQueue()
    {
        queueOrder = new MyStack<T>();
        stackOrder = new MyStack<T>();
    }

    public void Add(T item)
    {
        queueOrder.Push(item);

        stackOrder = new MyStack<T>(queueOrder.List.Reverse());
    }

    public T Remove()
    {
        if (IsEmpty())
            throw new Exception();

        T item = stackOrder.Pop();

        queueOrder = new MyStack<T>(stackOrder.List.Reverse());

        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new Exception();

        return stackOrder.Peek();
    }

    public bool IsEmpty()
    {
        return queueOrder.List.Count() == 0;
    }
}

