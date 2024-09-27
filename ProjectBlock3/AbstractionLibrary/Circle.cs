namespace AbstractionLibrary
{
    public class Circle : Shape
    {
        public double  Radius { get; set; }
        public override double GetArea() => Math.PI * Radius * Radius;        
    }
}
