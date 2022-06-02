using System;
using System.Collections.Generic;

namespace Project;

public class MinimalTree
{
    public Node Root { get; private set; }

    private IList<Node> _nodesInOrderTraversal;


    public MinimalTree(int[] array)
    {
        if (array is null || array.Length == 0)
            throw new ArgumentNullException();

        CreateMinimalTree(array, 0, array.Length - 1);
    }

    private Node CreateMinimalTree(int[] array, int startIndex, int endIndex)
    {
        if (startIndex > endIndex)
            return null;

        int midIndex = (startIndex + endIndex) / 2;
        Node mid = new Node(array[midIndex]);

        if (Root is null)
            Root = mid;

        mid.Left = CreateMinimalTree(array, startIndex, midIndex - 1);
        mid.Right = CreateMinimalTree(array, midIndex + 1, endIndex);

        return mid;
    }

    public IList<Node> GetNodesInOrderTraversal(Node root)
    {
        if (root is null)
            throw new ArgumentNullException();

        _nodesInOrderTraversal = new List<Node>();

        GetNodesInOrderTraversalHelper(root);

        return _nodesInOrderTraversal;
    }

    private void GetNodesInOrderTraversalHelper(Node root)
    {
        if (root is null)
            return;

        GetNodesInOrderTraversalHelper(root.Left);
        _nodesInOrderTraversal.Add(root);
        GetNodesInOrderTraversalHelper(root.Right);
    }
}

