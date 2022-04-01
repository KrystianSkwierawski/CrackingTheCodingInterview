using System;

namespace Project;

public class LinkedList<T> : ILinkedList<T>
{
    public Node<T> Head { get; set; }

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

    public T FindKthToLast(Node<T> head, int kth)
    {
        if (head is null || kth == 0)
            throw new ArgumentNullException();

        int length = GetLength(head);

        Node<T> node = FindByIndex(head, length, kth);

        if (node is not null)
            return node.Value;

        throw new Exception($"Not found an item: {nameof(head)} kth to last: {kth}");
    }

    private Node<T> FindByIndex(Node<T> head, int length, int kth)
    {
        // We can also use LinkedList.List.Select((value, index) => (value, index)).Single(x => x.index == searchingIndex);

        Node<T> current = head;
        int searchingIndex = length - kth;
        for (int index = 0; index < length; index++)
        {
            if (index == searchingIndex)
                return current;

            current = current.Next;
        }

        throw new Exception($"Not found an item: {nameof(head)} by index: {searchingIndex}");
    }

    private int GetLength(Node<T> head)
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

