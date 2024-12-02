namespace ProjectBlock8.ExampleException
{
    public class ExampleFormateException
    {

        public void ExampleMetod()
        {
            try
            {
                int input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Вы ввели число: " + input);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Ошибка: Некорректный формат числа!");
                Console.WriteLine("Сообщение: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Ошибка:  Число слишком большое или слишком маленькое!");
                Console.WriteLine("Сообщение: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при вводе числа!");
                Console.WriteLine("Сообщение: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally выполнен.");
            }
        }
    }
}
