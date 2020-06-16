using System;

namespace LinkedLists
{
    public class Item<T>
    {
        private T data = default(T);

        public T Data
        {
            get
            {
                return data;
            }
            set
            {
                if (value != null)
                    data = value;
                else
                    throw new ArgumentNullException("Данные не могут быть null.", nameof(value));
            }
        }
        public Item<T> Next { get; set; } = null;

        public Item(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return data.ToString(); 
        }
    }
}
