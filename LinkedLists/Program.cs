using System;
using Model_CircularLinkedList;
using Model_SinglyLinkedList;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestSinglyLinkedList();

            TestCircularLinkedList();

            Console.ReadLine();
        }

        /// <summary>
        /// Тест пройден!
        /// </summary>
        private static void TestCircularLinkedList()
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Вывожу от 0 до 5: ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine("Удаляй первый третий и последний элементы: ");
            list.Remove(0);
            list.Remove(2);
            list.Remove(0);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nПрибавляю к каждому + 3 и вывожу: ");
            for (int i = 0; i < list.Count; i++)
            {
                list[i] += 3;
                Console.WriteLine(list[i]);
            }


            Console.WriteLine("Добавляю два элемента (4 и 5):");
            list.Add(4);
            list.Add(5);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nДобавляю ко всем +3 и вывожу их с помощью цикла:");
            for (int i = 0; i < 4; i++)
            {
                list[i] += 3;
                Console.WriteLine(list[i]);
            }
        }

        /// <summary>
        /// Тест пройден!
        /// </summary>
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
