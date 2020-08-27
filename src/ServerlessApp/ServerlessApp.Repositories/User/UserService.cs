using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ServerlessApp.ViewModels.Dto;

namespace ServerlessApp.Repositories.User
{
    public class UserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _UserRepository = userRepository;
            _mapper = mapper;
        } 

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync() => _mapper.Map<IEnumerable<UserViewModel>>(await _UserRepository.GetAllUsersAsync());
        public async Task<Domain.User.User> CreateUserAsync(UserViewModel userViewModel)
        {
            //userViewModel.UserId = Guid.NewGuid();
            //userViewModel.CreatedDate = DateTime.UtcNow;

          return await _UserRepository.CreateUserAsync(_mapper.Map<Domain.User.User>(userViewModel));
        } 
        
    }
}
