namespace CustomExtensionsLibrary.Extensions
{
    /// <summary>
    /// Предоставляет методы расширения для типа <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Преобразует строку в целое число.
        /// </summary>
        /// <param name="value">Строковое представление числа.</param>
        /// <returns>Целое число.</returns>
        /// <exception cref="FormatException">Возникает, если строка не является числом.</exception>
        /// <exception cref="OverflowException">Возникает, если число выходит за пределы типа <see cref="int"/>.</exception>

        public static int ToInt(this string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            throw new FormatException($"Строка '{value}' не является допустимым целым числом.");
        }
    }
}
