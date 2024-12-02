namespace CustomExtensionsLibrary.Extensions
{
    /// <summary>
    /// Предоставляет методы расширения для типа <see cref="int"/>.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Определяет, является ли число простым.
        /// </summary>
        /// <param name="number">Число для проверки.</param>
        /// <returns><see langword="true"/>, если число простое; иначе <see langword="false"/>.</returns>

        public static bool IsPrime(this int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if ((number % i) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Вычисляет факториал числа.
        /// </summary>
        /// <param name="number">Число для вычисления факториала.</param>
        /// <returns>Факториал числа.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Возникает, если число меньше нуля.</exception>

        public static long Factorial(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(nameof(number), "Число не может быть отрицательным.");
            }

            if (number == 0 || number == 1)
            {
                return 1;
            }

            long result = 1;

            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
