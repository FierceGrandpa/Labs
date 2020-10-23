using System;
using System.Linq;

namespace SimpleListProject
{
    /// <summary>
    /// Стек
    /// </summary>
    /// <typeparam name="T"> Тип данных, хранимых в стеке. </typeparam>
    public class SimpleStack<T>
    {
        /// <summary>
        /// Коллекция хранимых данных.
        /// </summary>
        private readonly SimpleList<T> _items = new SimpleList<T>();

        /// <summary>
        /// Количество элементов стека.
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// Проверка стека на свойство: пуст. 
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Выполняется проверка на нахождение элемента в стеке.
        /// </summary>
        /// <param name="element"> Элемент </param>
        /// <returns></returns>
        public bool Contains(T element) => _items.Contains(element);

        /// <summary>
        /// Добавить данные в стек.
        /// </summary>
        /// <param name="element"> Добавляемые данные.  </param>
        public void Push(T element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));

            _items.Add(element);
        }

        /// <summary>
        /// Получить верхний элемент стека с удалением.
        /// </summary>
        /// <returns> Элемент данных. </returns>
        public T Pop()
        {
            var item = _items.LastOrDefault();

            if (item == null) throw new NullReferenceException("Стек пуст. Нет элементов для получения.");

            _items.Remove(item);

            return item;
        }

        /// <summary>
        /// Прочитать верхний элемент стека без удаления.
        /// </summary>
        /// <returns> Элемент данных. </returns>
        public T Peek()
        {
            var item = _items.LastOrDefault();

            if (item == null) throw new NullReferenceException("Стек пуст. Нет элементов для получения.");

            return item;
        }
    }
}