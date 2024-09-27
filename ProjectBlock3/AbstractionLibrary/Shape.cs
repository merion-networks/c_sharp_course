namespace AbstractionLibrary
{
    public abstract class Shape
    {
        public abstract double GetArea();

        public void Display()
        {
            Console.WriteLine("Это фигура!");
        }

    }
}
