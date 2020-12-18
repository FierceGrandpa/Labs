using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3.Simple
{
    public class SimpleList<T> : IEnumerable<T> where T : IComparable
    {
        public T this[int index] => Get(index);
        
        protected SimpleListItem<T> first;
        protected SimpleListItem<T> last;
        public int Count { get; protected set; }
        public void Add(T element)
        {
            var newItem = new SimpleListItem<T>(element);

            Count++;

            if (last == null)
            {
                first = newItem;
            }
            else
            {
                last.Next = newItem;
            }
            
            last = newItem;
        }
        public SimpleListItem<T> GetItem(int number)
        {
            if (number < 0 || number >= Count)
                throw new Exception("Выход за границу индекса");

            var current = first;

            var i = 0;

            while (i < number)
            {
                current = current.Next;

                i++;
            }
            return current;
        }
        public T Get(int number) => GetItem(number).Data;
        public IEnumerator<T> GetEnumerator()
        {
            var current = first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Sort() => Sort(0, Count - 1);
        private void Sort(int low, int high)
        {
            var i = low; var j = high;
            var x = Get((low + high) / 2);

            do
            {
                while (Get(i).CompareTo(x) < 0) ++i;
                while (Get(j).CompareTo(x) > 0) --j;

                if (i > j) continue;
                Swap(i, j);
                i++; j--;

            } while (i <= j);

            if (low < j)  Sort(low, j);
            if (i < high) Sort(i, high);
        }
        private void Swap(int i, int j)
        {
            var a = GetItem(i);
            var b = GetItem(j);

            var temp = a.Data;
            a.Data = b.Data;
            b.Data = temp;

        }
    }
}