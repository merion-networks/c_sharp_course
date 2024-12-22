using DependencyInjection.DI.Interface;


namespace DependencyInjection.DI
{
    public class NotificationController
    {
        private readonly IEmailService emailService;
        public NotificationController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public void Notify(string message)
        {
            emailService.SendEmail(message);
        }
    }
}
