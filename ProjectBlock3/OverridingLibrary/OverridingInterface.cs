namespace OverridingLibrary
{
    public interface IAddable<T>
    {
        T Add(T item);
    }

    public class Number : IAddable<Number>
    {
        public int Value { get; set; }

        public Number(int value)
        {
            Value = value;
        }

        public Number Add(Number item)
        {
            return new Number(this.Value + item.Value);
        }

        public static Number operator +(Number a, Number b)
        {
            return a.Add(b);
        }
    }

    public class GenericCalculation<T> where T : IAddable<T>
    {

        public T Add(T a, T b)
        {
            //Здесь возникает проблема: нельзя вызвать оператор +
            return a.Add(b);
        }

    }


    public class GenericDynamicCalculation<T>
    {

        public T Add(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            return da + db;
        }
    }

    internal class OverridingInterface
    {

        // `where T : class`, `where T : struct`)
    }
}
