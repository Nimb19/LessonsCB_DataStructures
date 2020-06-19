using System;

namespace BinaryTrees.BinaryTree
{
    public class Node<T> : IComparable<T> where T : IComparable<T>
    {
        public Node<T> Left { get; set; } 
        public Node<T> Right { get; set; }
        public T Data { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
