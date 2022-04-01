namespace Project;

public interface ILinkedList<T>
{
    public Node<T> Head { get; set; }
    public void AddLast(T value);
    public void RemoveDups(Node<T> head);
}

