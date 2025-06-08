using MediatR;
using UserManagement.Application.User.Dtos;

namespace UserManagement.Application.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
