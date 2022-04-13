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

    public Node<T> AddLast(dynamic value)
    {
        Node<T> end = (value is Node<T>) ? value as Node<T> : new Node<T>(value);

        if (Head is null)
        {
            Head = end;
            return Head;
        }

        Node<T> current = Head;

        while (current.Next is not null)
        {
            current = current.Next;
        }

        current.Next = end;

        return end;
    }

    public Node<T> GetBeginningOfTheLoopIfExists()
    {
        if (Head is null)
            throw new ArgumentNullException();

        IList<Node<T>> nodes = new List<Node<T>>();
        IList<Node<T>> duplicates = new List<Node<T>>();

        Node<T> node = Head;

        while (node is not null)
        {
            nodes.Add(node);

            duplicates = nodes.GroupBy(x => x)
             .Where(g => g.Count() > 1)
             .Select(y => y.Key).ToList();

            if (duplicates.Count() > 0)
                return duplicates.First();

            node = node.Next;
        }

        return null;
    }
}

