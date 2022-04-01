namespace Project;

public class LinkedList<T>
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

    public void RemoveDups(Node<T> head)
    {
        if (head is null)
            return;

        Node<T> current = head;

        while (current is not null)
        {
            Node<T> j = current;

            while (j?.Next is not null)
            {
                if (j.Next.Value.Equals(current.Value))
                {
                    j.Next = j.Next.Next;
                    continue;
                }

                if (!(j.Next.Value.Equals(current.Value)))
                {
                    j = j.Next;
                    continue;
                }
            }

            current = current.Next;
        }
    }
}

