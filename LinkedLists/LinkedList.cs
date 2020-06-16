using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedLists
{
    class SinglyLinkedList<T> : IEnumerable<T>
    {
        public Item<T> Head { get; private set; }
        public Item<T> Tail { get; private set; }
        public int Count { get; private set; }

        public SinglyLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public SinglyLinkedList(T data)
        {
            SetHeadAndTail(data);
        }

        public void Add(T data)
        {
            var item = new Item<T>(data);
            if (Tail != null)
            {
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data);
            }
        }

        public void Remove(int index)
        {
            if (index + 1 > Count || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы массива.\n" +
                    "Индекс должен быть положительным целочисленным числом " +
                    "и не должен выходить за пределы массива.");
            }

            if (index == 0)
            {
                Head = Head.Next;
                Count--;
                if (Count == 0)
                {
                    Tail = null;
                }
                return;
            }

            Item<T> previous = Head;
            Item<T> current = Head.Next;

            for (int i = 0; i <= index; i++)
            {
                if (i + 1 == index)
                {
                    previous.Next = current.Next;
                    Count--;
                    if (index == Count)
                    {
                        Tail = previous;
                    }
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count++;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Item<T> current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Item<T> current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index + 1 > Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы массива.\n" +
                        "Индекс должен быть положительным целочисленным числом " +
                        "и не должен выходить за пределы массива.");
                }

                T result = default(T);
                Item<T> current = Head;

                for (int i = 0; i <= index; i++)
                {
                    result = current.Data;

                    if (current.Next != null) 
                        current = current.Next;
                }

                return result;
            }
            set
            {
                if (index + 1 > Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Индекс выходит за границы массива. " +
                        "Индекс должен быть положительным целочисленным числом, " +
                        "так же он не должен выходить за пределы массива.", nameof(index));
                }

                Item<T> current = Head;

                for (int i = 0; i <= index; i++)
                {
                    if (i == index)
                        current.Data = value;

                    if (current.Next != null)
                        current = current.Next;
                }
            }
        }
    }
}
