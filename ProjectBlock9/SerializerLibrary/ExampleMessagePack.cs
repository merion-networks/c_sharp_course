using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializerLibrary.ExampleMessagePack
{
    [MessagePackObject]
    public class Person
    {
        [Key(0)]
        public string Name { get; set; }

        [Key(1)]
        public int Age { get; set; }
    }

    public class ExampleMessagePack
    {
        public void Example()
        {
            byte[] data = MessagePackSerializer.Serialize(new Person() { Age = 30 , Name = "Иван"});


            Person person = MessagePackSerializer.Deserialize<Person>(data);

            
        }
    }
}
