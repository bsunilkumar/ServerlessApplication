using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerlessApp.Domain.Tenant;
using ServerlessApp.Repositories.Tenant;
namespace ServerlessApp.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly TenantService TenantService;
        public TenantsController(TenantService tenantService) => TenantService = tenantService;
        
        [HttpGet]
        public async Task<IEnumerable<Tenant>> Get() => await TenantService.GetAllTenantsAsync();
       
    }
}