using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project;

public class Node<T>
{
    public Node<T> Next { get; set; }
    public T Value { get; set; }

    public IList<Node<T>> LinkedList
    {
        get
        {
            IList<Node<T>> o_result = new List<Node<T>>();

            Node<T> current = this;
            while (current is not null)
            {
                o_result.Add(current);

                current = current.Next;
            }

            return o_result;
        }
    }

    public Node(T value)
    {
        Value = value;
    }

    public static int SumLinkedLists(Node<int> node, Node<int> node2)
    {
        if (node is null || node2 is null)
            throw new ArgumentNullException();

        var linkedList1 = node.LinkedList.Reverse().ToArray();
        var linkedList2 = node2.LinkedList.Reverse().ToArray();

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

