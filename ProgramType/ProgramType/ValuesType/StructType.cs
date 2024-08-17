namespace ProgramType.ValuesType
{

    struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public double DistanceFromOrigin() => Math.Sqrt(X * X + Y * Y);
    }


    public class StructType
    {

        public StructType()
        {
            Point p1 = new Point(10, 45);
            Console.WriteLine(p1.DistanceFromOrigin());

        }
    }
}
