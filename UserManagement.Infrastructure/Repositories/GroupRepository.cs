using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.Persistence;

namespace UserManagement.Infrastructure.Repositories
{
    internal class GroupRepository(UserManagementDBContext dbContext) : IGroupRepository
    {
        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await dbContext.Groups.Include(g => g.Users).ToListAsync();
        }
    }
}
