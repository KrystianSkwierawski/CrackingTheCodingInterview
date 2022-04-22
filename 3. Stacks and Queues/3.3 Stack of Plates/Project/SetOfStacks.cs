using System;
using System.Collections.Generic;
using System.Linq;

namespace Project;

public class SetOfStacks<T>
{
    private const int _capacity = 3;
    public IList<MyStack<T>> Stacks { get; private set; } = new List<MyStack<T>>();

    public void Push(T item)
    {
        MyStack<T> currentStack = Stacks.LastOrDefault();

        if (currentStack is null || Stacks.Count() == 0 || currentStack.List.Count() >= _capacity)
        {
            currentStack = new MyStack<T>();
            Stacks.Add(currentStack);
        }

        currentStack.Push(item);
    }

    public T PopAt(int index)
    {
        MyStack<T> currentStack = Stacks
            .Select((stack, index) => (stack, index))
            .SingleOrDefault(x => x.index == index).stack;

        return Pop(currentStack);
    }

    public T Pop(MyStack<T>? stack)
    {
        MyStack<T> currentStack = stack ?? Stacks.LastOrDefault();

        if (currentStack is null)
            throw new Exception();

        T item = currentStack.Pop();

        if (currentStack.List.Count() == 0)
            Stacks.Remove(currentStack);

        return item;
    }

    public T Peek()
    {
        MyStack<T> currentStack = Stacks.LastOrDefault();

        if (currentStack is null)
            throw new Exception();

        return currentStack.Peek();
    }
}

