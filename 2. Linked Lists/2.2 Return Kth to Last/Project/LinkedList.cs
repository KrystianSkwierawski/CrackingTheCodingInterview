using System;
using System.Collections.Generic;

namespace Project;

public class LinkedList<T> : ILinkedList<T>
{
    public Node<T> Head { get; set; }

    public LinkedList(IList<T> list)
    {
        foreach (var node in list)
        {
            this.AddLast(node);
        }
    }

    public LinkedList()
    {

    }


    public void AddLast(T value)
    {
        if (Head is null)
        {
            Head = new Node<T>(value);
            return;
        }

        Node<T> current = Head;

        while (current.Next is not null)
        {
            current = current.Next;
        }

        current.Next = new Node<T>(value);
    }

    public T FindKthToLast(int kth)
    {
        if (Head is null)
            throw new ArgumentNullException();


        int length = GetLinkedListLength(Head);

        if (kth == 0)
            kth = length;

        Node<T> node = FindByIndex(length, kth);

        if (node is not null)
            return node.Value;

        throw new Exception($"Not found an item: {nameof(Head)} kth to last: {kth}");
    }

    private Node<T> FindByIndex(int length, int kth)
    {
        // We can also use LinkedList.List.Select((value, index) => (value, index)).Single(x => x.index == searchingIndex);

        Node<T> current = Head;
        int searchingIndex = length - kth;
        for (int index = 0; index < length; index++)
        {
            if (index == searchingIndex)
                return current;

            current = current.Next;
        }

        throw new Exception($"Not found an item: {nameof(Head)} by index: {searchingIndex}");
    }

    private int GetLinkedListLength(Node<T> head)
    {
        // We can also use LinkedList.List.Count();

        int o_length = 0;

        Node<T> current = head;

        while (current is not null)
        {
            o_length++;

            current = current.Next;
        }

        return o_length;
    }
}

