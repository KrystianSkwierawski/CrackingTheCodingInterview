using System;
using System.Collections.Generic;

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

    public static ILinkedList<int> GetIntersectingLinkedList(Node<int> node1, Node<int> node2)
    {
        if (node1 is null || node2 is null)
            throw new ArgumentNullException();

        IList<int> intersectingList = new List<int>();

        Node<int> current1 = node1;
        Node<int> previous1 = null;

        while (current1 is not null)
        {
            Node<int> current2 = node2;
            Node<int> previous2 = null;

            while (current2 is not null)
            {
                if (
                    (current1?.Value == current2?.Value && current1?.Next?.Value == current2?.Next?.Value) ||
                    (current1?.Value == current2?.Value && previous1?.Value == previous2?.Value)
                )
                {
                    intersectingList.Add(current1.Value);
                }

                previous2 = current2;
                current2 = current2.Next;
            }

            previous1 = current1;
            current1 = current1.Next;
        }

        return new LinkedList<int>(intersectingList);
    }
}

