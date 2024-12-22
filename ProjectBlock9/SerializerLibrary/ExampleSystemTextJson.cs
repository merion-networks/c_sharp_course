using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace SerializerLibrary.ExampleSystemTextJson
{
    public class Company
    {
        public string CompanyName { get; set; }
        public List<Person> Employees { get; set; }
    }

    public class Person
    {
        [JsonPropertyName("FullName")]

        public string Name { get; set; }

        //[JsonIgnore]
        public int Age { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    [JsonSourceGenerationOptions(
        WriteIndented = false,
        GenerationMode = JsonSourceGenerationMode.Default)]
    [JsonSerializable(typeof(Person))]
    [JsonSerializable(typeof(Address))]
    public partial class PersonJsonContext : JsonSerializerContext
    {
    }



    public class ExampleSystemTextJson
    {
        public void Example()
        {
            Person person = new Person
            {
                Name = "Иван",
                Age = 30,
                Address = new Address() { Street = "Test", City = "Test" }
            };

            Console.OutputEncoding = Encoding.UTF8;

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                // DefaultIgnoreCondition = JsonIgnoreCondition.Always
            };

            string jsonString = JsonSerializer.Serialize(person, options);


            Console.WriteLine(jsonString);


            string jsonContextString = JsonSerializer.Serialize(person, PersonJsonContext.Default.Person);

            Console.WriteLine(jsonContextString);

            Person deserializePerson = JsonSerializer.Deserialize<Person>(jsonString);

            Console.WriteLine($"{deserializePerson.Name} - {deserializePerson.Age}");


            Person deserializeContextPerson = JsonSerializer.Deserialize<Person>(jsonContextString, PersonJsonContext.Default.Person);

            Console.WriteLine($"{deserializeContextPerson.Name} - {deserializeContextPerson.Age}");


            List<Person> peoples = new List<Person>
                {
                    new Person { Name = "Иван", Age = 30 },
                    new Person { Name = "Мария", Age = 25 }
                };


            string jsonPeopleString = JsonSerializer.Serialize(peoples, options);

            Console.WriteLine(jsonPeopleString);

            Company company = new Company
            {
                CompanyName = "ООО Ромашка",
                Employees = peoples
            };


            string jsonCompanyString = JsonSerializer.Serialize(company, options);

            Console.WriteLine(jsonCompanyString);

        }

        public void ExampleUtf8Json()
        {
            Console.OutputEncoding = Encoding.UTF8;

            byte[] buffer = new byte[1024];
            using (var stream = new MemoryStream(buffer))
            using (var writer = new Utf8JsonWriter(stream, new JsonWriterOptions() { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }))
            {
                writer.WriteStartObject();
                writer.WriteString("Name", "Иван");
                writer.WriteNumber("Age", 30);
                writer.WriteEndObject();

            }

            string jsonString = Encoding.UTF8.GetString(buffer);
            Console.WriteLine(jsonString);

        }


    }
}
