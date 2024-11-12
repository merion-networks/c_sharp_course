using MyThirdProgram;

var shepes = new List<Shape>()
                {
                    new Circle(5),
                    new Rectangle(4,6),
                    new Triangle(3,4,5)
                };

foreach (var shape in shepes)
{
    shape.DisplayInfo();
    Console.WriteLine($"Площадь - {shape.GetArea():F2}");
    Console.WriteLine($"Периметр - {shape.GetPerimeter():F2}");
    Console.WriteLine(new string('-', 30));
}

Console.WriteLine("Фигуры отсортированы по площади.");
foreach (var shape in shepes.OrderBy(s => s.GetArea()))
{
    Console.WriteLine($"{shape.Name} | Площадь = {shape.GetArea():F2}");
}


shepes.Sort();

Console.WriteLine("Фигуры отсортированы по площади. (Используя IComparable )");
foreach (var shape in shepes)
{
    Console.WriteLine($"{shape.Name} | Площадь = {shape.GetArea():F2}");
}
