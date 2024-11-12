namespace MyThirdProgram
{
    /// <summary>
    /// Класс, представляющий круг.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Радиус круга.
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Имя фигуры.
        /// </summary>
        public override string Name => "Круг";

        /// <summary>
        /// Создает новый экземпляр класса Circle.
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус должен быть положительным числом.");

            Radius = radius;
        }

        /// <summary>
        /// Вычисляет площадь круга.
        /// </summary>
        public override double GetArea() => Math.PI * Math.Pow(Radius, 2);

        /// <summary>
        /// Вычисляет периметр (длину окружности) круга.
        /// </summary>
        public override double GetPerimeter() => 2 * Math.PI * Radius;

        /// <summary>
        /// Выводит информацию о круге.
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Радиус: {Radius}");
        }
    }

}
