using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public interface IExampleInterfaceB
    {
        void DoWork()
        {
            Console.WriteLine(nameof(IExampleInterfaceB));
        }
    }
}
