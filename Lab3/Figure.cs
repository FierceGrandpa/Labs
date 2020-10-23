using System;

namespace Lab3
{
    /// <summary>
    /// Абстрактный класс геометрической фигуры
    /// </summary>
    public abstract class Figure : IComparable<Figure>, IComparable, IPrint
    {
        public virtual double Area { get; }

        /// <summary>
        /// Метод для получения площади фигуры.
        /// </summary>
        /// <returns>Площадь.</returns>
        protected virtual double GetArea(Func<double> func) => func();

        /// <summary>
        /// Вывод информации о фигуре на консоль.
        /// </summary>
        public void Print() => Console.WriteLine(this.ToString());

        public int CompareTo(Figure figure) => this.Area.CompareTo(figure.Area);
        public int CompareTo(object obj)    => this.CompareTo(obj as Figure);
    }
}