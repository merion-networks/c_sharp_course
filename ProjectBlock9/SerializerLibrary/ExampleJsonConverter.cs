using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace SerializerLibrary
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string format = "yyyy-MM-dd";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string date = reader.GetString();
            return DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(format));
        }
    }



    public class Order
    {
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime OrderDate { get; set; }
    }


    public class ExampleJsonConverter
    {

        public void Example()
        {
            //var options = new JsonSerializerOptions
            //{
            //    Converters = { new DateTimeConverter() }
            //};


            Order order = new Order { OrderDate = DateTime.Now };

            string jsonString = JsonSerializer.Serialize(order);

            Console.WriteLine(jsonString);


        }
    }
}
