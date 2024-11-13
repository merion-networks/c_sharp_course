namespace ExtensionMethodsLibrary.Helpers
{
    public static class EnumerableExtensions
    {
        public static void ForEachAction<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
            {
                action(item);
            }
        }
    }
}
