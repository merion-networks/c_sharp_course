namespace OverridingLibrary
{
    public class BaseClass
    {
        public int Value { get; set; }

        public static BaseClass operator +(BaseClass a, BaseClass b)
        {
            return new BaseClass(a.Value + b.Value);
        }
        public virtual void Display()
        {
            Console.WriteLine("Что-то показать просит!");
        }

        public BaseClass(int value) { Value = value; }
    }
}
