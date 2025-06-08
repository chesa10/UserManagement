using MediatR;

namespace UserManagement.Application.User.Commands.UpdateUser
{
    public class UpdateUserRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public IEnumerable<int> GroupIds { get; set; }
    }
}
