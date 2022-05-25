using System.Collections.Generic;

namespace Project;

public class Node
{
    public int Value { get; set; }
    public bool Visited { get; set; } = false;
    public LinkedList<Node> Childrens { get; set; } = new LinkedList<Node>();
}

