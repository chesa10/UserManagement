using AutoMapper;

namespace UserManagement.Application.Group.Dtos
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Domain.Entities.Group, GroupDto>();
        }
    }
}
