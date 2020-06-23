using System;
using System.Collections.Generic;

namespace TrieTests.TrieFolder
{
    public class Node
    {
        public char Symbol { get; set; }
        public bool isWord { get; set; } = false;
        public List<Node> Descendants { get; set; } = new List<Node>();

        public Node(char symbol)
        {
            Symbol = symbol;
        }

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}
