﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public interface IExampleInterfaceA
    {
        void DoWork()
        {
            Console.WriteLine(nameof(IExampleInterfaceA));
        }
    }
}
