using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleListProject
{
    /// <summary>
    /// Класс реализующий список
    /// </summary>
    /// <typeparam name="T">Тип элементов списка.</typeparam>
    public class SimpleList <T> : IEnumerable<T>
    {
        /// <summary>
        /// Первый (головной) элемент списка.
        /// </summary>
        private Item<T> _head = null;

        /// <summary>
        /// Крайний (хвостовой) элемент списка. 
        /// </summary>
        private Item<T> _tail = null;

        /// <summary>
        /// Количество элементов списка.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Проверка листа на свойство: пуст. 
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Добавить данные в связный список.
        /// </summary>
        /// <param name="element"> Элемент для добавления в список. </param>
        public void Add(T element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));

            var item = new Item<T>(element);

            if (_head == null)
            {
                _head = item;
            }
            else
            {
                _tail.Next = item;
            }

            _tail = item;

            Count++;
        }

        /// <summary>
        /// Удалить данные из связного списка.
        /// Выполняется удаление первого вхождения данных.
        /// </summary>
        /// <param name="element"> Элемент, который будет удален. </param>
        public void Remove(T element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));

            var current = _head;

            Item<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(element))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null) _tail = previous;
                    }
                    else
                    {
                        _head = _head.Next;

                        if (_head == null) _tail = null;
                    }

                    Count--;
                    break;
                }

                previous = current;
                current  = current.Next;
            }
        }

        /// <summary>
        /// Выполняется проверка на нахождение элемента в списке.
        /// </summary>
        /// <param name="element"> Элемент </param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            Item<T> current = _head;
            while (current != null)
            {
                if (current.Data.Equals(element)) return true;
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        /// <summary>
        /// Вернуть перечислитель, выполняющий перебор всех элементов в связном списке.
        /// </summary>
        /// <returns> Перечислитель, который можно использовать для итерации по коллекции. </returns>
        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Вернуть перечислитель, который осуществляет итерационный переход по связному списку.
        /// </summary>
        /// <returns> Объект IEnumerator, который используется для прохода по коллекции. </returns>
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();
    }
}