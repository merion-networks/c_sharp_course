using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializerLibrary.ExampleXmlSerializer
{

    //Сравнение с DataContractSerializer:

    //| Характеристика                 | DataContractSerializer                           | XmlSerializer                 |
    //|--------------------------------|--------------------------------------------------|-------------------------------|
    //| Требование атрибутов           | [DataContract], [DataMember]                     | [Serializable], [XmlElement]  |
    //| Поддержка приватных членов     | Нет                                              | Нет                           |
    //| Контроль над XML структурой    | Ограниченный                                     | Более гибкий                  |
    //| Производительность             | Быстрее(использует отражение только при компиляции) | Медленнее(использует отражение во время выполнения) |


    [XmlRoot("Employee")]
    public class Person
    {
        [XmlElement("FullName")]
        public string Name { get; set; }

        [XmlAttribute("AgeAttribute")]
        public int Age { get; set; }

        [XmlIgnore]
        public string Address { get; set; }
    }


    public class Company
    {
        [XmlArray("Employees")]
        [XmlArrayItem("Employee")]
        public List<Person> Staff { get; set; }
    }

    public class ExampleXmlSerializer
    {


        public void Example()
        {
            Person person = new Person()
            {
                Name = "Иван",
                Age = 30,
                Address = "Россия, Москва"
            };
            string xml = string.Empty;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

            using (StringWriter sw = new StringWriter())
            {
                xmlSerializer.Serialize(sw, person);
                xml = sw.ToString();

                // Выводим XML на консоль
                Console.WriteLine("Сериализованный объект в формате XML:");
                Console.WriteLine(xml);
            }


            using (StringReader reader = new StringReader(xml))
            {
                Person deserializePerson = (Person)xmlSerializer.Deserialize(reader);

                // Выводим данные объекта на консоль
                Console.WriteLine("Десериализованный объект:");
                Console.WriteLine($"Имя: {deserializePerson.Name}");
                Console.WriteLine($"Возраст: {deserializePerson.Age}");
            }

        }




    }
}
