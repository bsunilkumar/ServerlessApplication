using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessApp.Repositories.Tenant
{
    public class TenantService
    {
        private readonly ITenantRepository _TenantRepository;

        public TenantService(ITenantRepository tenantRepository) => _TenantRepository = tenantRepository;
       
        public async Task<Domain.Tenant.Tenant> GetTenantByIdAsync(Guid tenantid) => await _TenantRepository.GetTenantByIdAsync(tenantid);
        public async Task<IEnumerable<Domain.Tenant.Tenant>> GetAllTenantsAsync() => await _TenantRepository.GetAllTenantsAsync();
    }
}
