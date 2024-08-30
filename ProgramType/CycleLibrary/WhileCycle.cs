using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleLibrary
{
    public class WhileCycle
    {
        void Example()
        {
            int i = 6;  
            while(i < 6)
            {
                i++;
                Console.WriteLine($"{i} - while({i < 6})");
            }
        }
        void ExampleSyntax()
        {
            while (true)
            {

            }
        }
        public WhileCycle() { Example(); }
    }
}
