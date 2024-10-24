namespace AnonymousLibrary
{
    public class LambdaClass
    {
        void Example()
        {
            //С параметром
            Action<string> greet = name => Console.WriteLine("Привет, " + name);
            greet("Анна!");

            //Без параметра
            Action sayHello = () => Console.WriteLine("Привет!");
            sayHello();

            //Многострочное лямбда-выродение
            Func<int, int, int> calculate = (x, y) =>
            {
                int result = x * y + y;
                Console.WriteLine("Результат операции - " + result);
                return result;
            };

            int multiplicatin = calculate(5, 4); 

        }
    }
}
