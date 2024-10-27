using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace GenericDelegateLibrary
{
    public class FuncClass
    {
        void Example()
        {
            Func<string, int> func = GetLengh;

            int result = func("Привет!");
        }

        private int GetLengh(string str)
        {
            return str.Length;
        }

        public void ExanpleFancLINQ()
        {
            List<string> names = new List<string>() { "Алиса", "Иван", "Чарли" };
            Func<string, string> selector = name => name.ToUpper();
            var upperNames = names.Select(selector);
        }

        public void ExampleDataConversion()
        {
            List<int> numbers = Enumerable.Range(0, 10).ToList();
            Func<int, double> square = x => x * x;
            Func<int, double> sqrt = x => Math.Sqrt(x);

            var squareNumber = numbers.Select(square);
            var sqrtNumbers = numbers.Select(sqrt);
        }

        public async Task ExampleAsync()
        {
            Func<string, Task<string>> getDataAsync = async (url) =>
            {
                using HttpClient httpClient = new HttpClient();
                return await httpClient.GetStringAsync(url);
            };

            string data = await getDataAsync("https://example.com");

            Console.WriteLine(data);
        }

        public void ExampleStrategy()
        {
            Func<decimal, decimal> noDiscount = price => price;
            Func<decimal, decimal> tenPercentDiscount = price => price * 0.9m;
            Func<decimal, decimal> seasonalPercentDiscount = price => price * 0.8m;


            decimal price = 100m;
            decimal finalPriceNoDiscount = CalculatePrice(price, noDiscount);
            decimal finalPricetenPercentDiscount = CalculatePrice(price, tenPercentDiscount);
            decimal finalPriceSeasonalPercentDiscount = CalculatePrice(price, seasonalPercentDiscount);
        }

        decimal CalculatePrice(decimal basePrice, Func<decimal, decimal> discountStrategy)
        {
            return discountStrategy(basePrice);

        }

        public void ExampleFilter()
        {
            Func<User, bool> BuildUserFilter(string name, int? age)
            {
                return user =>
                (string.IsNullOrEmpty(name) || user.Name.Contains(name)) && (age.HasValue || user.Age == age.Value);
            }

            var filter = BuildUserFilter("Ваня", null);
            // var users = dbContext.Users.Where(filter).ToList();
        }

        public void ExampleLizyData()
        {
            Func<List<string>> loadData = () =>
            {
                Thread.Sleep(5000);
                return new List<string> { "Data1", "Data2", "Data3" };
            };

            Lazy<List<string>> lizyData = new Lazy<List<string>>(loadData);

            var data = lizyData.Value;

            data.ToList().ForEach(x => Console.WriteLine(x));
        }

        public void ExampleParseMessage()
        {
            try
            {
                Func<string, Message> parseMassage = rawData =>
                {
                    return JsonConvert.DeserializeObject<Message>(rawData);
                };

                Action<Message> processMessage = message =>
                {
                    Console.WriteLine($"Получено сообщение от {message.Author}: {message.Content}");
                };

                string rawData = "{\"Author\": \"Alice\", \"Content\": \"Hello!\"}";

                Message message = parseMassage(rawData);
                processMessage(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
