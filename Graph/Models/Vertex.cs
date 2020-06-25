using System;
using System.Collections.Generic;

namespace Graph.Models
{
    internal class Vertex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Edge> Edges { get; set; } = new List<Edge>();

        public Vertex(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
