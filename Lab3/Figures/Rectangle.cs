using System;

namespace Lab3.Figures
{
    /// <summary>
    /// Прямоугольник
    /// </summary>
    public class Rectangle : Figure
    {
        /// <summary>
        /// Площадь.
        /// </summary>
        public override double Area => Width * Height;
        /// <summary>
        /// Ширина.
        /// </summary>
        public double Width  { get; }
        /// <summary>
        /// Высота.
        /// </summary>
        public double Height { get; }

        /// <summary>
        /// Геометрическая фигура Прямоугольник.
        /// </summary>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="height">Высота прямоугольника.</param>
        public Rectangle(double width, double height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), width, "Ширина не может быть <= 0.");
            }
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), height, "Высота не может быть <= 0.");
            }

            Width  = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"Прямоугольник: w = {Width}; h = {Height}; s = {Area}";
        }
    }
}