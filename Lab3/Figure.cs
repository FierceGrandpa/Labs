using System;

namespace Lab3
{
    /// <summary>
    /// Абстрактный класс геометрической фигуры
    /// </summary>
    public abstract class Figure : IComparable<Figure>, IComparable, IPrint
    {
        /// <summary>
        /// Площадь.
        /// </summary>
        public virtual double Area { get; }

        /// <summary>
        /// Вывод информации о фигуре на консоль.
        /// </summary>
        public void Print() => Console.WriteLine(this.ToString());

        public int CompareTo(Figure figure)
        {
            return figure != null
                ? this.Area.CompareTo(figure.Area)
                : throw new Exception("Impossible to compare these objects!");
        }

        public int CompareTo(object obj)
        {
            return obj is Figure figure
                ? Area.CompareTo(figure.Area)
                : throw new Exception("Impossible to compare these objects!");
        }
    }
}