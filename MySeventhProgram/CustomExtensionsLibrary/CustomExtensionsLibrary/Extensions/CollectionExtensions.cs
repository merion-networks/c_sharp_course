namespace CustomExtensionsLibrary.Extensions
{
    /// <summary>
    /// Предоставляет методы расширения для коллекций.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Возвращает уникальные элементы последовательности.
        /// </summary>
        /// <typeparam name="T">Тип элементов.</typeparam>
        /// <param name="source">Исходная последовательность.</param>
        /// <returns>Последовательность уникальных элементов.</returns>
        public static IEnumerable<T> GetUnique<T>(this IEnumerable<T> source)
        {
            return source.Distinct().ToList();
        }

        /// <summary>
        /// Преобразует последовательность в строку с разделителем.
        /// </summary>
        /// <typeparam name="T">Тип элементов.</typeparam>
        /// <param name="source">Исходная последовательность.</param>
        /// <param name="separator">Разделитель.</param>
        /// <returns>Строковое представление последовательности.</returns>
        public static string ToSeparatorString<T>(this IEnumerable<T> source, string separator = ".")
        {
            return string.Join(separator, source);
        }
    }
}
