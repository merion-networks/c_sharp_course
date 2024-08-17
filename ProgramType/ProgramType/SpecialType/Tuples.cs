using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramType.SpecialType
{
    public class Tuples
    {

        public (int Sum, int Product) Calculate(int a, int b)
        {
            return (a + b, a * b);
        }

        public Tuples()
        {
            (string, int) person = ("Alice", 25);
            Console.WriteLine($"Name : {person.Item1}, Age: {person.Item2}");

            (string Name, int Age) personNew = ("Alice", 25);

            Console.WriteLine($"Name : {personNew.Name}, Age: {personNew.Age}");


            var result = Calculate(2, 5);
            Console.WriteLine($"Sum : {result.Sum}, Product: {result.Product}");

        }
    }
}
