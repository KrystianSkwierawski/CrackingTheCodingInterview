using System;

namespace Project
{
    static class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            var (start, end) = graph.InitializeTestData();

            graph.Print();

            Console.ReadLine();
        }
    }
}
