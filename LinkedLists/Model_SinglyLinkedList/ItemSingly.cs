using System;

namespace Model_SinglyLinkedList
{
    public class ItemSingly<T>
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
        public ItemSingly<T> Next { get; set; } = null;

        public ItemSingly(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return data.ToString(); 
        }
    }
}
