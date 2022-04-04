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

    public Node<T> AddLast(T value)
    {
        if (Head is null)
        {
            Head = new Node<T>(value);
            return Head;
        }

        Node<T> current = Head;
        Node<T> previous = null;


        while (current.Next is not null)
        {
            previous = current;
            current = current.Next;
        }

        current.Previous = previous;

        Node<T> end = new Node<T>(value);
        current.Next = end;

        return end;
    }

    public void DeleteMiddleNode(Node<T> middleNode)
    {
        if (middleNode is null)
            throw new ArgumentNullException();

        if (middleNode.Previous is null || middleNode.Next is null)
            throw new Exception("Not a middle node");

        Node<T> previous = middleNode.Previous;
        previous.Next = previous.Next.Next;
    }
}

