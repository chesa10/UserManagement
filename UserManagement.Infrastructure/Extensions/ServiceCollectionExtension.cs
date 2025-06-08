using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.DataSeeders;
using UserManagement.Infrastructure.Persistence;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("UserManagementDBConnectionString");
            services.AddDbContext<UserManagementDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IGroupSeeder, GroupSeeder>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
        }
    }
}
