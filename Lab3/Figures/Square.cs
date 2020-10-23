namespace Lab3.Figures
{
    /// <summary>
    /// Квадрат
    /// </summary>
    public class Square : Rectangle, IPrint
    {
        /// <summary>
        /// Геометрическая фигура Квадрат.
        /// </summary>
        /// <param name="lengthSide">Длина стороны квадрата.</param>
        public Square(double lengthSide) : base(lengthSide, lengthSide) { }
        
        public override string ToString()
        {
            return $"Фигура: Квадрат\nДлинна стороны = {Width}\nПлощадь = {Area}";
        }
    }
}