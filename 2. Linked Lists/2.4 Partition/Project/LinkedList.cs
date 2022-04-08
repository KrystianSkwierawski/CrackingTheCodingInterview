using System;
using System.Collections.Generic;
using System.Linq;

namespace Project;

public class LinkedList<T> : ILinkedList<T>
{
    public Node<T> Head { get; set; }
    public IList<Node<T>> List
    {
        get
        {
            IList<Node<T>> o_result = new List<Node<T>>();

            Node<T> current = Head;
            while (current is not null)
            {
                o_result.Add(current);

                current = current.Next;
            }

            return o_result;
        }
    }

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

    public Node<T> AddLast(T value)
    {
        if (Head is null)
        {
            Head = new Node<T>(value);
            return Head;
        }

        Node<T> current = Head;


        while (current.Next is not null)
        {
            current = current.Next;
        }


        Node<T> end = new Node<T>(value);
        current.Next = end;

        return end;
    }

    public LinkedList<int> DoPartition(int x)
    {
        Node<int> head = Head as Node<int>;

        var (leftPartiton, RightPartiton) = GetLeftAndRightPartition(head, x);

        IList<int> partitions = leftPartiton.Concat(RightPartiton).ToList();

        return new LinkedList<int>(partitions);
    }

    private (IList<int>, IList<int>) GetLeftAndRightPartition(Node<int> head, int x)
    {
        IList<int> lessThanX = new List<int>();
        IList<int> greaterOrEqualToX = new List<int>();

        Node<int> current = head;
        while (current is not null)
        {
            if (current.Value < x)
                lessThanX.Add(current.Value);

            if (current.Value >= x)
                greaterOrEqualToX.Add(current.Value);

            current = current.Next;
        }

        return (lessThanX, greaterOrEqualToX);
    }
}

