namespace AbstractionLibrary
{
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Light { get; set; }
        public override double GetArea()
        {
            return Width * Light;
        }
    }
}
