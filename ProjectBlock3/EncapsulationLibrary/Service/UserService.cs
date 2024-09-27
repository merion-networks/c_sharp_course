using EncapsulationLibrary.Interface;
using EncapsulationLibrary.Model;

namespace EncapsulationLibrary.Service
{
    public class UserService
    {
        private IUserRepository userRepository;
        private IEmailService emailService;


        public void RegisterUser(RegisterModel registerModel)
        {
            //Бизнес логика 

            var user = new User();
            userRepository.AddUser(user);
            emailService.SendWelcomeEmail(user.Email);
        }


        public UserService(IUserRepository userRepository, IEmailService emailService)
        {
            this.userRepository = userRepository;
            this.emailService = emailService;
        }
    }
}
