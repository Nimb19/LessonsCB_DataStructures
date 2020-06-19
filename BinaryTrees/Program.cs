using System;
using BinaryTrees.BinaryTree;

namespace BinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(2);
            tree.Add(8);
            tree.Add(6);
            tree.Add(4);
            tree.Add(9);

            Console.WriteLine("Префиксным способом: ");

            foreach (var item in tree.Preorder())
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nПостфиксным способом: ");

            foreach (var item in tree.PostOreder())
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nИнфиксным образом: ");

            foreach (var item in tree.InOrder())
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nТесты пройдены!");

            Console.ReadLine();
        }
    }
}
