using NHibernate;
using NHibernate.Linq;
using ServerlessApp.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ServerlessApp.Repositories.Tenant
{
    public class TenantRepository : RepositoryBase<Domain.Tenant.Tenant>, ITenantRepository
    {
       
        public TenantRepository(ISession session) : base(session)
        {
            
        }
        public async Task<IEnumerable<Domain.Tenant.Tenant>> GetAllTenantsAsync() => await GetAll().OrderBy(x => x.Name).ToListAsync();
        public async Task<Domain.Tenant.Tenant> GetTenantByIdAsync(Guid guid) => await FindByCondition(x => x.TenantId == guid).SingleOrDefaultAsync();
    }
}
