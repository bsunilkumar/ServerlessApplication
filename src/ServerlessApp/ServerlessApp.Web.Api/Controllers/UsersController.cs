
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerlessApp.Repositories.User;
using ServerlessApp.ViewModels.Dto;

namespace ServerlessApp.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService UserService;
        public UsersController(UserService userService) => UserService = userService;
        
        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> Get() => await UserService.GetAllUsersAsync();
       [HttpPost("User-Management")]
        public async Task<ActionResult<Domain.User.User>> Post([FromBody]UserViewModel userViewModel)
        {            
            return await UserService.CreateUserAsync(userViewModel);
        }
    }
}
