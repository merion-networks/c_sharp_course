using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFiveProgram
{
    public class EventArguments : EventArgs
    {
        public string Message {  get; }

        public EventArguments(string message) { Message = message; }
    }
}
