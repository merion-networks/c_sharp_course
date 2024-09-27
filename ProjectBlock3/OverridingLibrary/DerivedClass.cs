namespace OverridingLibrary
{
    public class DerivedClass : BaseClass
    {
        public override void Display()
        {
            Console.WriteLine("Что-то свое покажи!");
            // base.Display();
        }

        public static DerivedClass operator +(DerivedClass a, DerivedClass b)
        {
            return new DerivedClass(a.Value + b.Value);
        }

        public DerivedClass(int value) : base(value) { }

    }
}
