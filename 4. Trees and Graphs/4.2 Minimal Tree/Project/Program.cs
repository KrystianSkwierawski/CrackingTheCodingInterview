using System;

namespace Project
{
    static class Program
    {
        static int[] _sortedArray = new int[] { 1, 2, 3, 4, 5 };

        static void Main(string[] args)
        {
            PrintNodesInOrderTraversal();
            PrintNodesInPreOrderTraversal();
            PrintNodesPostInOrderTraversal();

            Console.ReadLine();
        }

        private static void PrintNodesInOrderTraversal()
        {
            MinimalTree minimalTree = new MinimalTree(_sortedArray);

            Console.WriteLine("InOrderTraversalNodes ----->");
            var inOrderTraversalNodes = minimalTree.GetNodes(minimalTree.Root, TypeOfTraversals.InOrderTraversal);

            foreach (var item in inOrderTraversalNodes)
            {
                Console.WriteLine($"{item.Value}, ");
            }

            Console.WriteLine();
        }

        private static void PrintNodesInPreOrderTraversal()
        {
            MinimalTree minimalTree = new MinimalTree(_sortedArray);

            Console.WriteLine("PreOrderTraversalNodes ----->");
            var preOrderTraversalNodes = minimalTree.GetNodes(minimalTree.Root, TypeOfTraversals.PreOrderTraversal);

            foreach (var item in preOrderTraversalNodes)
            {
                Console.WriteLine($"{item.Value}, ");
            }

            Console.WriteLine();
        }

        private static void PrintNodesPostInOrderTraversal()
        {
            MinimalTree minimalTree = new MinimalTree(_sortedArray);

            Console.WriteLine("PostOrderTraversalNodes ----->");
            var postOrderTraversalNodes = minimalTree.GetNodes(minimalTree.Root, TypeOfTraversals.PostOrderTraversal);

            foreach (var item in postOrderTraversalNodes)
            {
                Console.WriteLine($"{item.Value}, ");
            }

            Console.WriteLine();
        }
    }
}
