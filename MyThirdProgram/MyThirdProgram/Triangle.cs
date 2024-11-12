namespace MyThirdProgram
{
    /// <summary>
    /// Класс, представляющий треугольник.
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Длина стороны A.
        /// </summary>
        public double SideA { get; }

        /// <summary>
        /// Длина стороны B.
        /// </summary>
        public double SideB { get; }

        /// <summary>
        /// Длина стороны C.
        /// </summary>
        public double SideC { get; }

        /// <summary>
        /// Имя фигуры.
        /// </summary>
        public override string Name => "Треугольник";

        /// <summary>
        /// Создает новый экземпляр класса Triangle.
        /// </summary>
        /// <param name="sideA">Длина стороны A.</param>
        /// <param name="sideB">Длина стороны B.</param>
        /// <param name="sideC">Длина стороны C.</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (!IsValidTriangle(sideA, sideB, sideC))
                throw new ArgumentException("Стороны не образуют треугольник.");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        /// <summary>
        /// Проверяет, могут ли стороны образовать треугольник.
        /// </summary>
        private bool IsValidTriangle(double sideA, double sideB, double sideC) => 
            sideA > 0 && sideB > 0 && sideC > 0 && 
            sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA;

        /// <summary>
        /// Вычисляет площадь треугольника по формуле Герона.
        /// </summary>
        public override double GetArea()
        {
            double s = GetPerimeter() / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        /// <summary>
        /// Вычисляет периметр треугольника.
        /// </summary>
        public override double GetPerimeter() => SideA + SideB + SideC;

        /// <summary>
        /// Выводит информацию о треугольнике.
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Стороны: {SideA}, {SideB}, {SideC}");
        }
    }

}
