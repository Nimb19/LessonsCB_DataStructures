using System;
using System.Collections;
using System.Collections.Generic;

namespace Model_CircularLinkedList
{
    public class CircularLinkedList<T> : IEnumerable
    {
        private ItemDoubly<T> head { get; set; }
        public int Count { get; set; }

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
                if (Count == 0)
                {
                    SetFirstProps(data);
                    return;
                }

                ItemDoubly<T> item = new ItemDoubly<T>(data);
                item.Next = head;
                item.Previous = head.Previous;
                head.Previous = item;
                item.Previous.Next = item;
                Count++;
            }
            else
            {
                throw new ArgumentNullException(nameof(data), "Данные не могут быть null.");
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы массива.\n" +
                "Индекс должен быть положительным целочисленным числом " +
                "и не должен выходить за пределы массива.");
            }

            ItemDoubly<T> current = head;

            if (Count - index >= index)
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
                        Count--;
                        return;
                    }

                    current = current.Next;
                }
            }
            else
            {
                for (int i = Count; i >= index; i--)
                {
                    if (i == index)
                    {
                        current.Previous = current.Next;
                        current.Next.Previous = current.Previous;
                        Count--;
                        return;
                    }

                    current = current.Previous;
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
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы массива.\n" +
                    "Индекс должен быть положительным целочисленным числом " +
                    "и не должен выходить за пределы массива."); 
                }

                ItemDoubly<T> current = head;

                if (Count - index >= index)
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
                    for (int i = Count; i >= index; i--)
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
                if (index < 0 || index >= Count)
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

                if (Count - index >= index)
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
                    for (int i = Count; i >= index; i--)
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
            Count++;
        }

        private void SetDefaultProps()
        {
            head = null;
            Count = 0;
        }

        public IEnumerator GetEnumerator()
        {
            ItemDoubly<T> curr = head.Previous;
            for(int i = 0; i < Count; i++)
            {
                curr = curr.Next;
                yield return curr.Data;
            }
        }
    }
}
