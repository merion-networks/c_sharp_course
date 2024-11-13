
namespace ExtensionMethodsLibrary.Helpers
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string input)
        {
            return double.TryParse(input, out double result);
        }

        public static string Truncate(this string input, int maxLenght)
        {
            if (maxLenght <= 0)
                throw new ArgumentException();

            if(string.IsNullOrEmpty(input)) return input;

            return input.Length <= maxLenght ? input : input.Substring(0,maxLenght);
        }
    }
}
