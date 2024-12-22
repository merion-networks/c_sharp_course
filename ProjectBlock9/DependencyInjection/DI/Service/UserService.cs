using DependencyInjection.DI.Interface;


namespace DependencyInjection.DI.Service
{
    public class UserService : IUserService
    {
        public Guid GetUserById(int id)
        {
            return Guid.NewGuid(); 
        }
    }
}
