﻿using System;

namespace SimpleListProject
{
    /// <summary>
    /// Класс, описывающий элемент списка
    /// </summary>
    /// <typeparam name="T"> Тип хранимых данных. </typeparam>
    public class Item<T>
    {
        /// <summary>
        /// Хранимые данные.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Следующий элемент связного списка.
        /// </summary>
        public Item<T> Next { get; set; }

        /// <summary>
        /// Создание нового экземпляра связного списка.
        /// </summary>
        /// <param name="data"> Сохраняемые данные. </param>
        public Item(T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Data = data;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Хранимые данные. </returns>
        public override string ToString() => Data.ToString();
    }
}