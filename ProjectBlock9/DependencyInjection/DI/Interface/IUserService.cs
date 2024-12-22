using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.DI.Interface
{
    public interface IUserService
    {
        Guid GetUserById(int id);

    }
}
