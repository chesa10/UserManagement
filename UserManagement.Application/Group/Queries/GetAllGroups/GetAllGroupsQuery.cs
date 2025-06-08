using MediatR;
using UserManagement.Application.Group.Dtos;

namespace UserManagement.Application.Group.Queries.GetAllGroups
{
    public class GetAllGroupsQuery : IRequest<IEnumerable<GroupDto>>
    {
    }
}
