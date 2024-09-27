namespace InheritanceLibrary
{
    public class Square : Shape
    {
        public double Side { get; set; }
        public override double GetArea()
        {
            return Side * Side;
        }
    }
}
