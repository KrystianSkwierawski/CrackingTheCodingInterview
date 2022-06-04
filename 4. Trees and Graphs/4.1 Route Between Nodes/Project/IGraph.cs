namespace Project;

public interface IGraph
{
    bool IsRouteBetweenTwoRoutes(Node start, Node end, TypeOfSearch typeOfSearch = TypeOfSearch.DFS);
    Node AddNode(int value);
    void LinkNodes(Node root, params Node[] nodes);
    (Node, Node) InitializeTestData();
    void Print();
}

