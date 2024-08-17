using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablesLibrary
{
    public class Record
    {
        public record Person(string FirstName, string LastName, int Age);

        public Record()
        {
            var person = new Person("Ivan", "Ivanovich", 45);
            var personNew = person with { Age = 30 };


            Console.WriteLine(person);
            Console.WriteLine(personNew);
        }
    }
}
