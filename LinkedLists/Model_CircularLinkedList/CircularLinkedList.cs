using System;
using System.Collections;
using System.Collections.Generic;

namespace Model_CircularLinkedList
{
    public class CircularLinkedList<T> : IEnumerable
    {
        private ItemDoubly<T> head { get; set; }
        public int Length { get; set; }

        public CircularLinkedList()
        {
            SetDefaultProps();
        }

        public CircularLinkedList(T data)
        {
            SetFirstProps(data);
        }

        public void Add(T data)
        {
            if (data != null)
            {
                if (Length == 0)
                {
                    SetFirstProps(data);
                    return;
                }

                ItemDoubly<T> item = new ItemDoubly<T>(data);
                item.Next = head;
                item.Previous = head.Previous;
                head.Previous = item;
                item.Previous.Next = item;
                Length++;
            }
            else
            {
                throw new ArgumentNullException(nameof(data), "Данные не могут быть null.");
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы массива.\n" +
                "Индекс должен быть положительным целочисленным числом " +
                "и не должен выходить за пределы массива.");
            }

            ItemDoubly<T> current = head;

            if (Length - index >= index)
            {
                for (int i = 0; i <= index; i++)
                {
                    if (i == index)
                    {
                        if (index == 0)
                        {
                            head = current.Next;
                        }
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        Length--;
                        return;
                    }

                    current = current.Next;
                }
            }
            else
            {
                for (int i = Length; i >= index; i--)
                {
                    if (i == index)
                    {
                        current.Previous = current.Next;
                        current.Next.Previous = current.Previous;
                        Length--;
                        return;
                    }

                    current = current.Previous;
                }
            }
        }

        public void RemoveEveryThirdEl()
        {
            ItemDoubly<T> current = head.Previous;

            while (Length > 2)
            {
                for (int i = 0; i <= 2; i++)
                {
                    current = current.Next;
                    
                    if (i == 2)
                    {
                        if (current == head)
                        {
                            head = current.Next;
                        }
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        Length--;
                        Console.WriteLine("Удалён элемент " + current.Data);
                    }
                }
            }
        }

        public void Clear()
        {
            SetDefaultProps();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы массива.\n" +
                    "Индекс должен быть положительным целочисленным числом " +
                    "и не должен выходить за пределы массива."); 
                }

                ItemDoubly<T> current = head;

                if (Length - index >= index)
                {
                    for (int i = 0; i <= index; i++)
                    {
                        if (i == index)
                        {
                            return current.Data;
                        }

                        current = current.Next;
                    }
                }
                else 
                {
                    for (int i = Length; i >= index; i--)
                    {
                        if (i == index)
                        {
                            return current.Data;
                        }

                        current = current.Previous;
                    }
                }

                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы массива.\n" +
                    "Индекс должен быть положительным целочисленным числом " +
                    "и не должен выходить за пределы массива.");
                }

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Данные не могут быть null.");
                }

                ItemDoubly<T> current = head;

                if (Length - index >= index)
                {
                    for (int i = 0; i <= index; i++)
                    {
                        if (i == index)
                        {
                            current.Data = value;
                        }

                        current = current.Next;
                    }
                }
                else
                {
                    for (int i = Length; i >= index; i--)
                    {
                        if (i == index)
                        {
                            current.Data = value;
                        }

                        current = current.Previous;
                    }
                }
            }
        }

        private void SetFirstProps(T data)
        {
            ItemDoubly<T> item = new ItemDoubly<T>(data);
            head = item;
            head.Next = item;
            head.Previous = item;
            Length++;
        }

        private void SetDefaultProps()
        {
            head = null;
            Length = 0;
        }

        public IEnumerator GetEnumerator()
        {
            ItemDoubly<T> curr = head.Previous;
            for(int i = 0; i < Length; i++)
            {
                curr = curr.Next;
                yield return curr.Data;
            }
        }
    }
}
