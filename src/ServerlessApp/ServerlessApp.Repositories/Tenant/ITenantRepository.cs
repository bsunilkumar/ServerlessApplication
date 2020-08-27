using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessApp.Repositories.Tenant
{
    public interface ITenantRepository
    {
        Task<IEnumerable<Domain.Tenant.Tenant>> GetAllTenantsAsync();
        Task<Domain.Tenant.Tenant> GetTenantByIdAsync(Guid guid);
    }
}
