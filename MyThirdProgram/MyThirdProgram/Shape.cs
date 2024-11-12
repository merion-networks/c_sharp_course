namespace MyThirdProgram
{
    /// <summary>
    /// Абстрактный класс, представляющий геометрическую фигуру.
    /// </summary>
    public abstract class Shape : IComparable<Shape>
    {
        /// <summary>
        /// Имя фигуры.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Вычисляет площадь фигуры.
        /// </summary>
        public abstract double GetArea();

        /// <summary>
        /// Вычисляет периметр фигуры.
        /// </summary>
        public abstract double GetPerimeter();

        /// <summary>
        /// Выводит информацию о фигуре.
        /// </summary>
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Фигура: {Name}");
        }

        /// <summary>
        /// Сравнивает текущую фигуру с другой по площади.
        /// </summary>
        /// <param name="other">Другая фигура для сравнения.</param>
        public int CompareTo(Shape? other)
        {
            if(other == null) return 1;
            return GetArea().CompareTo(other.GetArea());
        }
    }
}
