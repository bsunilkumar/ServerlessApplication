using AutoMapper;
using ServerlessApp.Domain.User;
using ServerlessApp.ViewModels.Dto;

namespace ServerlessApp.ViewModels.Profiles
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            /*CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));*/

            CreateMap<UserViewModel, User>();
            //.ConstructUsing(c => new User(){c.UserId= Guid.NewGuid(), c.UserName, c.FirstName});
        }
    }
}
