using MediatR;
using UserManagement.Application.Group.Dtos;

namespace UserManagement.Application.Group.Queries.GetGroupUserCount
{
    internal class GetGroupUserCountQuery : IRequest<GroupUserCountDto>
    {
    }
}
