﻿using System;

namespace Lab3.Figures
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Площадь.
        /// </summary>
        public override double Area => Math.PI * Radius * Radius;
        /// <summary>
        /// Радиус.
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Геометрическая фигура Круг.
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), radius, "Радиус не может быть <= 0.");
            }

            Radius = radius;
        }
        
        public override string ToString()
        {
            return $"Круг: r = {Radius}; s = {Area}";
        }
    }
}