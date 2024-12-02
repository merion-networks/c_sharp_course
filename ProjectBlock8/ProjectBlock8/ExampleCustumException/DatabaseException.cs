using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlock8.ExampleCustumException
{
    public class DatabaseException : Exception
    {
        public string ServerName { get; }
        public DatabaseException(string serverName, string message) : base(message)
        {
            ServerName = serverName;
        }
    }
}
