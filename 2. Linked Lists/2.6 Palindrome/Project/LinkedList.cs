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

    public bool IsPalidrome()
    {
        if (Head is null)
            throw new ArgumentNullException();

        return Enumerable.SequenceEqual(
                List.Select(x => x.Value),
                List.Reverse().Select(x => x.Value)
            );
    }
}

