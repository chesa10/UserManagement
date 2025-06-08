using MediatR;
using UserManagement.Application.User.Dtos;

namespace UserManagement.Application.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
