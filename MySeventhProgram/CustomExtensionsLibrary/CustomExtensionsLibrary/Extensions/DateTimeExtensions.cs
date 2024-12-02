namespace CustomExtensionsLibrary.Extensions
{
    /// <summary>
    /// Предоставляет методы расширения для типа <see cref="DateTime"/>.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Преобразует дату в Unix Timestamp.
        /// </summary>
        /// <param name="dateTime">Дата и время.</param>
        /// <returns>Unix Timestamp.</returns>
        public static long ToToUnixTimestamp(this DateTime dateTime)
        {
            DateTimeOffset dateOffset = new DateTimeOffset(dateTime.ToUniversalTime());
            return dateOffset.ToUnixTimeSeconds();
        }

        /// <summary>
        /// Определяет, является ли дата выходным днем.
        /// </summary>
        /// <param name="dateTime">Дата для проверки.</param>
        /// <returns><see langword="true"/>, если дата приходится на субботу или воскресенье; иначе <see langword="false"/>.</returns>
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
