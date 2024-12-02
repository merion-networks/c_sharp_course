namespace ProjectBlock8.ExampleException
{
    public class ExampleDivadeByZero : IExample
    {

        void Metod(int number)
        {

            if (number < 0)
            {
                throw new ArgumentException("Не должно быть равен или мень нуля!");
            }

            try
            {
                int result = 10 / number;

                Console.WriteLine("Результат: " + result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ExampleMetod()
        {
            try
            {
                int input = int.Parse(Console.ReadLine());
                Metod(input);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Ошибка: Деление на ноль!");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: Любая другая!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally выполнен.");
            }
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
