using System.Collections.Generic;
using System.Xml.Linq;

namespace Project;

public class Graph
{
    private LinkedList<Node> _nodes { get; set; } = new LinkedList<Node>();

    public bool IsRouteBetweenTwoRoutes(Node start, Node end, TypeOfSearch typeOfSearch = TypeOfSearch.DFS)
    {
        if (typeOfSearch == TypeOfSearch.DFS)
            return DFSSearch(start, end);

        if (typeOfSearch == TypeOfSearch.BFS)
            return BFSSearch(start, end);

        return false;
    }

    public bool DFSSearch(Node root, Node end)
    {
        if (root is null || end is null)
            return false;

        if (root == end)
            return true;

        root.Visited = true;

        foreach (var children in root.Childrens)
        {
            if (children.Visited == true)
                continue;

            return DFSSearch(children, end);
        }

        return false;
    }

    public bool BFSSearch(Node root, Node end)
    {
      

        return false;
    }

    public Node AddNode(int value)
    {
        Node node = new Node { Value = value };

        _nodes.AddLast(node);

        return node;
    }

    public void LinkNodes(Node root, params Node[] nodes)
    {
        foreach (var node in nodes)
        {
            root.Childrens.AddLast(node);
        }
    }

    public (Node, Node) InitializeTestData()
    {
        Node node0 = AddNode(0);
        Node node1 = AddNode(1);
        Node node3 = AddNode(3);
        Node node2 = AddNode(2);
        Node node4 = AddNode(4);
        Node node5 = AddNode(5);

        LinkNodes(node0, node1, node4, node5);
        LinkNodes(node1, node3, node4);
        LinkNodes(node3, node2, node4);
        LinkNodes(node2, node1);

        return (node0, node3);
    }

    public void Print()
    {
        foreach (var node in _nodes)
        {
            System.Console.WriteLine(node.Value + "->");

            foreach (var children in node.Childrens)
            {
                System.Console.WriteLine(children.Value + ",");
            }

            System.Console.WriteLine();

        }
    }
}

