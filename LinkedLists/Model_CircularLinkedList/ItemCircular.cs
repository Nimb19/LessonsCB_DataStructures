using System;

namespace Model_CircularLinkedList
{
    public class ItemDoubly<T>
    {
        private T data = default(T);
        public ItemDoubly<T> Previous { get; set; }
        public ItemDoubly<T> Next { get; set; }
        public T Data 
        { 
            get 
            { 
                return data; 
            } 
            set 
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), "Данные не могут быть null.");
                else
                    data = value;
            } 
        }

        public ItemDoubly(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
