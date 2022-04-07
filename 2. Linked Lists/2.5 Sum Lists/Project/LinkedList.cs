using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    public int SumLists(ILinkedList<T> linkedList)
    {
        if (linkedList is null)
            throw new ArgumentNullException();

        var linkedList1 = this.List.Reverse().ToArray();
        var linkedList2 = linkedList.List.Reverse().ToArray();

        StringBuilder linkedList1Number = new(linkedList1.Length);
        StringBuilder linkedList2Number = new(linkedList2.Length);


        // I assumed here that the lists would be the same length
        for (int i = 0; i < linkedList1.Length; i++)
        {
            linkedList1Number.Append(
                    linkedList1[i].Value
                );

            linkedList2Number.Append(
                  linkedList2[i].Value
              );
        }

        int result = Int32.Parse(linkedList1Number.ToString()) + Int32.Parse(linkedList2Number.ToString());

        // When we want a LinkedList of the result
        //ILinkedList<T> resultLinkedList = new LinkedList<T>(
        //        (IList<T>)result.ToString().Split(',').Select(Int32.Parse).ToList()
        //    );

        return result;
    }
}

