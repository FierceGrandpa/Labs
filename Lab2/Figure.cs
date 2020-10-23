using System;

namespace Lab2
{
    /// <summary>
    /// Абстрактный класс геометрической фигуры
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Метод для получения площади фигуры.
        /// </summary>
        /// <returns>Площадь.</returns>
        protected virtual double GetArea(Func<double> func) => func();

        /// <summary>
        /// Вывод информации о фигуре на консоль.
        /// </summary>
        public void Print() => Console.WriteLine(this.ToString());
    }
}