using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleLibrary
{
    public class DoWhileCycle
    {
        void Example()
        {
            int i = 6;

            do
            {
                i++;
                Console.WriteLine($"{i} - while({i < 6})");
            }
            while (i < 6);

        }
        void ExampleSyntax()
        {
            do
            {

            }
            while (true);
        }

        public DoWhileCycle() { Example(); }
    }
}
