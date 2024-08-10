namespace MyFirstProgram
{
    // Пользовательское исключение
    public class CustomException : Exception
    {
        public CustomException() : base() { }
        public CustomException(string message) : base(message) { }
        public CustomException(string message, Exception inner) : base(message, inner) { }
    }

    /// <summary>
    /// Тема: Исключения
    /// </summary>
    public class MyException
    {
        // Метод для проверки возраста
        public void CheckAge(int age)
        {
            if (age < 0)
                throw new ArgumentException("Возраст не может быть отрицательным!");
        }


        public MyException()
        {
            try
            {
                // Инициализация массива
                int[] numbers = { 1, 2, 3 };
                Console.WriteLine(numbers[0]);

                Console.WriteLine("Без ошибки");
                CheckAge(numbers[0]);
                Console.WriteLine("С ошибкой");

                // Намеренно вызываем исключение
                CheckAge(-10);
            }
            catch (ArgumentException ex)
            {
                // Обработка исключения ошибок в аргументах метода
                Console.WriteLine($"Ошибка - {ex.Message}");
            }
            catch (IndexOutOfRangeException ex)
            {
                // Обработка исключения выхода за границы массива
                Console.WriteLine($"Ошибка - {ex.Message}");
            }
            catch (Exception ex)
            {
                // Обработка общего исключения
                Console.WriteLine($"Ошибка - {ex.Message}");
                throw; // Повторно генерируем исключение
            }
            finally
            {
                // Этот блок выполнится всегда
                Console.WriteLine("Это всегда выполнится!");
            }
        }
    }
}
