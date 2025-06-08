using UserManagement.Web.Services.ServiceModel;

namespace UserManagement.Web.Services.Abstractions
{
    public interface IUserHttpService
    {
        Task<int> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<List<User>> GetUserListAsync();
        Task DeleteUser(int id);
        Task<User> GetUserById(int id);
    }
}
