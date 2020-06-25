using System;
using System.Collections.Generic;

namespace Graph.Models
{
    internal class Graph
    {
        List<Vertex> Vertexes = new List<Vertex>();
        List<Edge> Edges = new List<Edge>();

        public void AddVertex(string name)
        {
            var vertex = new Vertex(name, Vertexes.Count);
            Vertexes.Add(vertex);
        }

        public void AddEdge(string from, string to, int weight = 1)
        {
            Vertex fromV = null;
            Vertex toV = null;
            foreach (var item in Vertexes)
            {
                if (item.Name == from)
                {
                    fromV = item;
                    break;
                }
            }
            foreach (var item in Vertexes)
            {
                if (item.Name == to)
                {
                    toV = item;
                    break;
                }
            }
            if (fromV == null || toV == null)
            {
                throw new ArgumentException("Неправильно вписано название вершины.");
            }

            var edge = new Edge(fromV, toV, weight);
            fromV.Edges.Add(edge);
            Edges.Add(edge);
        }

        public bool WaveSearch(string start, string requiredElement)
        {
            if (start == requiredElement)
            {
                return true;
            }

            Vertex startV = null;
            Vertex toV = null;
            foreach (var item in Vertexes)
            {
                if (item.Name == start)
                {
                    startV = item;
                    break;
                }
            }
            foreach (var item in Vertexes)
            {
                if (item.Name == requiredElement)
                {
                    toV = item;
                    break;
                }
            }
            if (startV == null || toV == null)
            {
                throw new ArgumentException("Неправильно вписано название вершины.");
            }

            var list = new List<Vertex>() { startV };
            var visited = new List<Vertex>();

            for (int i = 0; i < list.Count; i++)
            {
                var vertex = list[i];
                foreach (var v in vertex.Edges)
                {
                    if (!visited.Contains(v.To))
                    {
                        visited.Add(v.To);
                        list.Add(v.To);
                    }
                }
            }

            return list.Contains(toV);
        }

        public int[,] GetMatrix()
        {
            var matrix = new int[Vertexes.Count, Vertexes.Count];

            foreach (var edge in Edges)
            {
                matrix[edge.From.Id, edge.To.Id] = edge.Weight;
            }

            return matrix;
        }
    }
}
