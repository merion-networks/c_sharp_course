namespace ExtensionMethodsLibrary.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime EndOfDateTime(this DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddMilliseconds(-1);
        }
    }
}
