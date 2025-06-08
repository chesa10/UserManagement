using UserManagement.Application.Group.Dtos;


namespace UserManagement.Application.User.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public List<GroupDto> Groups { get; set; } = new();
    }
}
