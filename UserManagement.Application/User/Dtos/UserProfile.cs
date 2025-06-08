using AutoMapper;
using UserManagement.Application.User.Commands.AddUser;
using UserManagement.Application.User.Commands.UpdateUser;

namespace UserManagement.Application.User.Dtos
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Entities.User, UserDto>();
            CreateMap<UserDto, Domain.Entities.User>();
            CreateMap<Domain.Entities.User, AddUserRequest>();
            CreateMap<AddUserRequest, Domain.Entities.User>();
            CreateMap<UpdateUserRequest, Domain.Entities.User>();
        }
    }
}
