using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<int> Create(User user);
        Task<bool> Delete(User user);
        Task<bool> Update(User user);
    }
}
