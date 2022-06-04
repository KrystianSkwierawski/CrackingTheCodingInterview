using System;
using System.Collections.Generic;
using System.Linq;

namespace Project;

public class MinimalTree : IMinimalTree
{
    public Node Root { get; set; }

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

    public IList<Node> GetNodes(Node root, TypeOfTraversals typeOfTraversal = TypeOfTraversals.InOrderTraversal)
    {
        if (root is null)
            throw new ArgumentNullException();

        _nodesInOrderTraversal = new List<Node>();

        if (typeOfTraversal is TypeOfTraversals.InOrderTraversal)
            GetNodesInOrderTraversal(root);

        if (typeOfTraversal is TypeOfTraversals.PreOrderTraversal)
            GetNodesInPreOrderTraversal(root);

        if (typeOfTraversal is TypeOfTraversals.PostOrderTraversal)
            GetNodesInPostOrderTraversal(root);

        if (typeOfTraversal is TypeOfTraversals.Node)
            throw new ArgumentException();

        return _nodesInOrderTraversal;
    }

    private void GetNodesInOrderTraversal(Node root)
    {
        if (root is null)
            return;

        GetNodesInOrderTraversal(root.Left);
        _nodesInOrderTraversal.Add(root);
        GetNodesInOrderTraversal(root.Right);
    }

    private void GetNodesInPreOrderTraversal(Node root)
    {
        if (root is null)
            return;

        _nodesInOrderTraversal.Add(root);
        GetNodesInOrderTraversal(root.Left);
        GetNodesInOrderTraversal(root.Right);
    }

    private void GetNodesInPostOrderTraversal(Node root)
    {
        if (root is null)
            return;

        GetNodesInOrderTraversal(root.Left);
        GetNodesInOrderTraversal(root.Right);
        _nodesInOrderTraversal.Add(root);
    }
}

