using MediatR;

namespace UserManagement.Application.User.Commands.AddUser
{
    public class AddUserRequest :  IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public IEnumerable<int> GroupIds { get; set; }
    }
}
