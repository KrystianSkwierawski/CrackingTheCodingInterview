using System;

namespace Project
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] treeArr = new int[] { 1, 2, 4, 5, 6, 7, 8, 9 };
            MinimalTree minimalTree = new MinimalTree(treeArr);

            minimalTree.PrintInOrderTraversal(minimalTree.Root);

            Console.ReadLine();
        }
    }
}
