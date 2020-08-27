using NHibernate;
using NHibernate.Linq;
using ServerlessApp.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessApp.Repositories.User
{
    public class UserRepository : RepositoryBase<Domain.User.User>, IUserRepository
    {
        
        public UserRepository(ISession session) : base(session)
        {
            
        }

        public async Task<IEnumerable<Domain.User.User>> GetAllUsersAsync() => await GetAll().OrderBy(x => x.UserName).ToListAsync();
        public async Task<Domain.User.User> CreateUserAsync(Domain.User.User user) => await SaveOrUpdateAsync(user);
        
    }
}
