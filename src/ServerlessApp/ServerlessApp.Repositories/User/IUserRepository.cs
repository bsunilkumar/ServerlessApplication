using ServerlessApp.Domain.User;
using ServerlessApp.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessApp.Repositories.User
{
    public interface IUserRepository
    {
       Task<IEnumerable<Domain.User.User>> GetAllUsersAsync();
       Task<Domain.User.User> CreateUserAsync(Domain.User.User user);
    }
}
