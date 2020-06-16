using System;
using System.Collections.Generic;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSinglyLinkedList();

            Console.ReadLine();
        }

        private static void TestSinglyLinkedList()
        {
            var list = new SinglyLinkedList<string>();
            list.Add("5dsbsd");
            list.Add("2sdgsg");
            list.Add("7sdgsdg");

            try
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                list.Remove(2);
                list.Remove(0);

                Console.WriteLine("\nУдалены 3 и 1 элементы!\n");

                list.Add("Этот будет последним из двух, по идее");
                list.Add("Ку, теперь я третий");
                list.Add("Четвёртый");

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\nУдаляю первый и последний. Далее опять первый\n");

                list.Remove(list.Count - 1);
                list.Remove(0);
                list.Remove(0);

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\nДолжен быть только третий, УДАЛЯЮ ПОСЛЕДНИЙ:\n");

                list.Remove(0);

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("В массиве должно быть ноль элементов, и вывести не должно было ничего\nПрисваиваю снова два элемента и удаляю последний:\n");

                list.Add("Выживший первый");
                list.Add("Не выживший второй");

                list.Remove(list.Count - 1);

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
