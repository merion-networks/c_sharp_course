using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace SerializerLibrary.ExampleDataContractSerializer
{
//Сравнение с XmlSerializer:

//| Характеристика                 | DataContractSerializer                           | XmlSerializer                 |
//|--------------------------------|--------------------------------------------------|-------------------------------|
//| Требование атрибутов           | [DataContract], [DataMember]                     | [Serializable], [XmlElement]  |
//| Поддержка приватных членов     | Нет                                              | Нет                           |
//| Контроль над XML структурой    | Ограниченный                                     | Более гибкий                  |
//| Производительность             | Быстрее(использует отражение только при компиляции) | Медленнее(использует отражение во время выполнения) |


    [DataContract]
    public class Company
    {
        [DataMember]
        public List<Person> Employees { get; set; }
    }

    [DataContract]
    public class Employee : Person
    {
        public string Position { get; set; }
    }

    [DataContract]
    public class Manager : Employee
    {
        [DataMember]
        public int TeamSize { get; set; }
    }

    [DataContract]
    [KnownType(typeof(Employee))] // Указываем известные типы
    [KnownType(typeof(Manager))]
    public class Person
    {
        [DataMember(Name = "FullName", Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 1)]
        public int Age { get; set; }

        // Это свойство НЕ будет сериализовано, так как не помечено [DataMember]
        [IgnoreDataMember]
        public string Address { get; set; }
    }

    public class ExampleDataContractSerializer
    {

        private void ShowPerson(Person? person, string message)
        {

            Console.WriteLine($"\n{message}");
            Console.WriteLine($"Имя: {person?.Name}");
            Console.WriteLine($"Возраст: {person?.Age}");
            Console.WriteLine($"Адрес: {person?.Address}"); // Будет null, так как Address не сериализовался
        }

        public void Example()
        {
            Person person = new Person()
            {
                Name = "Иван",
                Age = 30,
                Address = "Россия, Москва"
            };


            ShowPerson(person, "Объект:");

            DataContractSerializerSettings settings = new DataContractSerializerSettings()
            {
                PreserveObjectReferences = true, // Для поддержки циклических ссылок
                KnownTypes = new List<Type> { typeof(Employee), typeof(Manager) }
            };

            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(Person), settings);

            using (FileStream writer = new FileStream("person.xml", FileMode.Create))
            {
                dataContractSerializer.WriteObject(writer, person);
            }



            Console.WriteLine("Объект сериализован в файл person.xml");
            Console.WriteLine("Содержимое файла:");

            string xmlContent = File.ReadAllText("person.xml");
            Console.WriteLine(xmlContent);


            DataContractJsonSerializerSettings settingsJson = new DataContractJsonSerializerSettings()
            {
                KnownTypes = new List<Type> { typeof(Employee), typeof(Manager) }
            };


            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Person), settingsJson);

            using (FileStream writer = new FileStream("person.json", FileMode.Create))
            {
                dataContractJsonSerializer.WriteObject(writer, person);
            }

            Console.WriteLine("Объект сериализован в файл person.json");
            Console.WriteLine("Содержимое файла:");

            string jsonContent = File.ReadAllText("person.json");
            Console.WriteLine(jsonContent);

            Person deserializedPerson;
            Person deserializedJsonPerson;

            using (FileStream reader = new FileStream("person.xml", FileMode.Open))
            {
                deserializedPerson = (Person)dataContractSerializer.ReadObject(reader);
            }

            using (FileStream reader = new FileStream("person.json", FileMode.Open))
            {
                deserializedJsonPerson = (Person)dataContractJsonSerializer.ReadObject(reader);
            }

            ShowPerson(deserializedPerson, "Десериализованный объект:");
            ShowPerson(deserializedJsonPerson, "Десериализованный JSON объект:");
        }
    }
}
