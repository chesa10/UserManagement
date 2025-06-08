using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Repositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllAsync();
    }
}
