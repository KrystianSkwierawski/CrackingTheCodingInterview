using System.Collections.Generic;

namespace Project;

public interface ILinkedList<T>
{
    public Node<T> Head { get; set; }
    public IList<Node<T>> List { get; }    
    public Node<T> AddLast(T value);
    public void DoPartition(Node<int> node, int x);
}

