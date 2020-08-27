using AutoMapper;
using ServerlessApp.Domain.User;
using ServerlessApp.ViewModels.Dto;

namespace ServerlessApp.ViewModels.Profiles
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
