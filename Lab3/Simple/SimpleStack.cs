using System;

namespace Lab3.Simple
{
    class SimpleStack<T> : SimpleList<T> where T : IComparable
    {
        public void Push(T element) => Add(element);

        public T Pop()
        {
            if (Count == 0) 
                throw new Exception("Ошибка! Стек пустой, извлечение элемента невозможно.");

            var top = Get(Count - 1);

            if (Count == 1)
            {
                first = null;
                last = null;
            }
            else
            {
                last = GetItem(Count - 2);
                last.Next = null;
            }

            Count--;

            return top;
        }
    }
}