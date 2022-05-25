using System;

namespace Project
{
    static class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.InitializeTestData();

            graph.Print();

            Console.ReadLine();
        }
    }
}
