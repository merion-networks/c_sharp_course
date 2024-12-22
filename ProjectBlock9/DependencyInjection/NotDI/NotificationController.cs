using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.NotDI
{
    public class NotificationController
    {
        private EmailService emailService;

        public NotificationController()
        {
            emailService = new EmailService();
        }

        public void Notify(string message)
        {
            emailService.SendEmail(message);
        }

    }
}
