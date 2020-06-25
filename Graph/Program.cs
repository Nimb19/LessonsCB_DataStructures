using System;
using Graph.Models;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Models.Graph graph = new Models.Graph();

            graph.AddVertex("vertex1");
            graph.AddVertex("vertex2");
            graph.AddVertex("vertex3");
            graph.AddVertex("vertex4");
            graph.AddVertex("vertex5");

            graph.AddEdge("vertex1", "vertex2", 5);
            graph.AddEdge("vertex1", "vertex3", 7);
            graph.AddEdge("vertex2", "vertex4", 3);
            graph.AddEdge("vertex3", "vertex4", 7);
            graph.AddEdge("vertex4", "vertex2", 9);
            graph.AddEdge("vertex2", "vertex5", 2);
            graph.AddEdge("vertex5", "vertex2", 1);
            //graph.AddEdge("vertex5", "vertex1", 4);

            var matrix = graph.GetMatrix();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(graph.WaveSearch("vertex2", "vertex3"));
            Console.WriteLine(graph.WaveSearch("vertex4", "vertex5"));

            Console.ReadLine();
        }
    }
}
