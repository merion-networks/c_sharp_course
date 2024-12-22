using DependencyInjection.DI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.DI.Service
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Отправка email: {message}");
        }
    }
}
