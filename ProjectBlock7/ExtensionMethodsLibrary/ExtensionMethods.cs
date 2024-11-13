using ExtensionMethodsLibrary.Helpers;
using Microsoft.Extensions.Logging;
using System.Data;

namespace ExtensionMethodsLibrary
{
    public class ExtensionMethods
    {


        ILogger logger;
        public void ExampleStringExtension()
        {
            string value = "12345";
            bool isNumeric = value.IsNumeric();

            var newValue = value.Truncate(2);
        }

        public void ExampleIntExtension()
        {
            int value = 21;
            string ordinal = value.ToOrdinal();
        }

        public void ExampleEnumerableExtension()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            numbers.ForEachAction(x => Console.WriteLine(x));
        }

        public void ExampleDictionaryExtension()
        {
            var dict = new Dictionary<string, int>() { { "Test", 1 }, { "Test2", 2 }, { "Test3", 3 } };
            dict.GetSorterValueOrDefault("test2", 2);
        }

        public void ExampleDateTimeExtensions()
        {
            DateTime now = DateTime.Now;
            DateTime endOfDay = now.EndOfDateTime();
        }

        public void ExampleFileInfoExtensions()
        {
            FileInfo file = new FileInfo("source.txt");
            if (file.Exists)
            {
                file.CopyToDirectory(@"C:\Users\79191\source\repos\MerionAcademy\ProjectBlock7\ProjectBlock7\bin\Debug\net8.0\temp");
            }
        }

        public async Task ExampleHttpClientExtensions()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var data = await httpClient.GetJsonAsync<MyStatus>("https://macademy.free.beeceptor.com/data");
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex, "Ошибка поймана:");
            }
        }
    }
}
