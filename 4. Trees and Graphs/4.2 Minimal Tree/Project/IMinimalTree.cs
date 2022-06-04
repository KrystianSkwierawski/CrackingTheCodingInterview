using System.Collections.Generic;

namespace Project;

public interface IMinimalTree
{
    public Node Root { get; set; }
    IList<Node> GetNodes(Node root, TypeOfTraversals typeOfTraversal = TypeOfTraversals.InOrderTraversal);
}

