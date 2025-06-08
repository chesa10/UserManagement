using MediatR;

namespace UserManagement.Application.User.Commands.DeleteUser
{
    public class DeleteUserRequest : IRequest
    {
        public int Id { get; set; }
    }
}
