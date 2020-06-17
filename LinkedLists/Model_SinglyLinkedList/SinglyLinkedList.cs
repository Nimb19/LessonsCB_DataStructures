using System;
using System.Collections;
using System.Collections.Generic;

namespace Model_SinglyLinkedList
{
    class SinglyLinkedList<T> : IEnumerable
    {
        public ItemSingly<T> Head { get; private set; }
        public ItemSingly<T> Tail { get; private set; }
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
            var ItemSingly = new ItemSingly<T>(data);
            if (Tail != null)
            {
                Tail.Next = ItemSingly;
                Tail = ItemSingly;
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

            ItemSingly<T> previous = Head;
            ItemSingly<T> current = Head.Next;

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
            var ItemSingly = new ItemSingly<T>(data);
            Head = ItemSingly;
            Tail = ItemSingly;
            Count++;
        }

        public IEnumerator GetEnumerator()
        {
            ItemSingly<T> current = Head;

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
                ItemSingly<T> current = Head;

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

                ItemSingly<T> current = Head;

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
