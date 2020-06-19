using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTrees.BinaryTree
{
    public class Tree<T> where T : IComparable<T>
    {
        private Node<T> root { get; set; }
        public int Length { get; private set; }

        public Tree() { }

        public Tree(T data)
        {
            Add(data);
        }

        public List<T> Preorder()
        {
            if (root == null)
            {
                return new List<T>();
            }

            List<T> listRes = new List<T>();

            var current = root;
            List<Node<T>> nodes = new List<Node<T>>();
            bool isNew = true;

            while (listRes.Count != Length)
            {
                if (isNew)
                {
                    listRes.Add(current.Data);
                    if (listRes.Count == Length)
                    {
                        return listRes;
                    }
                }

                if (current.Left != null && current.Right != null && isNew == true)
                {
                    nodes.Add(current);
                }

                if (current.Left != null && isNew == true)
                {
                    current = current.Left;
                    continue;
                }
                else if (current.Right != null)
                {
                    current = current.Right;
                    if (!isNew)
                    {
                        nodes.RemoveAt(nodes.Count - 1);
                    }
                    isNew = true;
                    continue;
                }
                else
                {
                    current = nodes.Last();
                    isNew = false;
                }
            }

            throw new Exception("Произошла неизвестная ошибка.");
        }

        public List<T> PostOreder()
        {
            if (root == null)
            {
                return new List<T>();
            }

            List<T> listRes = new List<T>();

            var current = root;
            List<Node<T>> nodes = new List<Node<T>>();
            List<Node<T>> nodesRazv = new List<Node<T>>();
            bool isNew = true;

            while (listRes.Count != Length)
            {
                if (current.Left != null && current.Right != null && isNew == true)
                {
                    nodesRazv.Add(current);
                }

                if (current.Left != null && isNew == true)
                {
                    nodes.Add(current);
                    current = current.Left;
                }
                else if (current.Right != null && isNew == true)
                {
                    nodes.Add(current);
                    current = current.Right;
                }
                else if (nodesRazv.Contains(current) && isNew == false)
                {
                    current = current.Right;
                    nodesRazv.RemoveAt(nodesRazv.Count - 1);
                    isNew = true;
                }
                else
                {
                    listRes.Add(current.Data);
                    if (listRes.Count == Length)
                    {
                        return listRes;
                    }

                    current = nodes.Last();
                    isNew = false;

                    if (!nodesRazv.Contains(current))
                    {
                        nodes.RemoveAt(nodes.Count - 1);
                    }
                }
            }

            throw new Exception("Неизвестная ошибка.");
        }

        public List<T> InOrder()
        {
            if (root == null)
            {
                return new List<T>();
            }

            List<T> listRes = new List<T>();

            var current = root;
            List<Node<T>> nodes = new List<Node<T>>();
            List<Node<T>> nodesRoads = new List<Node<T>>();
            bool isNew = true;

            while (listRes.Count != Length)
            {
                if (current.Left != null && current.Right != null && isNew == true)
                {
                    nodesRoads.Add(current);
                }

                if (current.Left != null && isNew == true)
                {
                    nodes.Add(current);
                    current = current.Left;
                    continue;
                }
                else if (current.Right != null && isNew == true)
                {
                    listRes.Add(current.Data);
                    current = current.Right;
                    continue;
                }
                else if (nodesRoads.Contains(current) && isNew == false)
                {
                    listRes.Add(current.Data);
                    isNew = true;
                    current = current.Right;
                    nodesRoads.RemoveAt(nodesRoads.Count - 1);
                    continue;
                }
                else
                {
                    listRes.Add(current.Data);
                    if (listRes.Count == Length)
                    {
                        return listRes;
                    }
                    current = nodes.Last();
                    isNew = false;

                    nodes.RemoveAt(nodes.Count - 1);
                    continue;
                }
            }

            throw new Exception("Неизвестная ошибка.");
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (root == null)
            {
                root = node;
                Length++;
                return;
            }

            var current = root;
            while (true)
            {
                if (current.Data.CompareTo(data) == 1) // 6 > 5 = 1
                {
                    if (current.Left == null)
                    {
                        current.Left = node;
                        break;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = node;
                        break;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            }

            Length++;
        }
    }
}
