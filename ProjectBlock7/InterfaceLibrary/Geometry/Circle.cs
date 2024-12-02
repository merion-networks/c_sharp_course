
namespace InterfaceLibrary.Geometry
{
    public class Circle : IShape
    {
        public int Radius { get; }

        public Circle(int radius)
        {
            Radius = radius;
        }
        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
