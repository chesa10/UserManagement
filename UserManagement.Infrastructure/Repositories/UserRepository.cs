using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.Persistence;

namespace UserManagement.Infrastructure.Repositories
{
    internal class UserRepository(UserManagementDBContext dbContext) : IUserRepository
    {
        public async Task<int> Create(User user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> Delete(User user)
        {
            dbContext.Users.Remove(user);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        { 
            return await dbContext.Users.Include(u => u.Groups).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await dbContext.Users
                .Include(x => x.Groups)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<bool> Update(User user)
        {
            dbContext.Users.Update(user);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
