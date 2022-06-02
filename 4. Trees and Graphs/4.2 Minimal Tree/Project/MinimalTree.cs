using System;
using System.Collections.Generic;

namespace Project;

public class MinimalTree
{
    public Node Root { get; private set; }

    public IList<Node> NodesInOrderTraversal
    {
        get
        {
            NodesInOrderTraversal = new List<Node>();
            PrintInOrderTraversal(Root);
            return NodesInOrderTraversal;
        }
        private set => NodesInOrderTraversal = value;
    }

    public MinimalTree(int[] array)
    {
        Helper(array, 0, array.Length - 1);
    }

    private Node Helper(int[] array, int startIndex, int endIndex)
    {
        if (startIndex > endIndex)
            return null;

        int midIndex = (startIndex + endIndex) / 2;
        Node mid = new Node(array[midIndex]);

        if (Root is null)
            Root = mid;

        mid.Left = Helper(array, startIndex, midIndex - 1);
        mid.Right = Helper(array, midIndex + 1, endIndex);

        return mid;
    }

    public void PrintInOrderTraversal(Node root)
    {
        if (root is null)
            return;

        PrintInOrderTraversal(root.Left);

        Console.WriteLine(root.Value);
        NodesInOrderTraversal.Add(root);

        PrintInOrderTraversal(root.Right);
    }
}

