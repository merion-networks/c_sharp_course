namespace MyThirdProgram
{
    /// <summary>
    /// Класс, представляющий прямоугольник.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Ширина прямоугольника.
        /// </summary>
        public double Width { get; }

        /// <summary>
        /// Высота прямоугольника.
        /// </summary>
        public double Height { get; }

        /// <summary>
        /// Имя фигуры.
        /// </summary>
        public override string Name => "Прямоугольник";

        /// <summary>
        /// Создает новый экземпляр класса Rectangle.
        /// </summary>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="height">Высота прямоугольника.</param>
        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Ширина и высота должны быть положительными числами.");

            Width = width;
            Height = height;
        }

        /// <summary>
        /// Вычисляет площадь прямоугольника.
        /// </summary>
        public override double GetArea() => Width * Height;

        /// <summary>
        /// Вычисляет периметр прямоугольника.
        /// </summary>
        public override double GetPerimeter() => 2 * (Width + Height);

        /// <summary>
        /// Выводит информацию о прямоугольнике.
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Ширина: {Width}");
            Console.WriteLine($"Высота: {Height}");
        }
    }
}
