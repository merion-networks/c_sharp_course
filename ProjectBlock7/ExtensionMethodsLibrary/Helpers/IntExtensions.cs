namespace ExtensionMethodsLibrary.Helpers
{
    public static class IntExtensions
    {
        public static string ToOrdinal(this int number)
        {
            if (number <= 0) return number.ToString();

            int rem = number % 100;

            if (rem >= 11 && rem <= 13) return $"{number}th";

            switch (number % 10)
            {
                case 1: return $"{number}st";
                case 2: return $"{number}nd";
                case 3: return $"{number}rd";
                default: return $"{number}th";
            }
        }
    }
}
