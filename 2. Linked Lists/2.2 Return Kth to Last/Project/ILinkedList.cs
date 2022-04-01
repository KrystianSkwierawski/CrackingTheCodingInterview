namespace Project;

public interface ILinkedList<T>
{
    public Node<T> Head { get; set; }
    public void AddLast(T value);
    public T FindKthToLast(Node<T> head, int kth);
}

