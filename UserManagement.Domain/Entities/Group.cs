namespace UserManagement.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; } = new();
        public List<Permission> Permissions { get; set; } = new();
    }
}
