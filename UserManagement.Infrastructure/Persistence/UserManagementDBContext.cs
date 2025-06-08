using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Persistence
{
    internal class UserManagementDBContext(DbContextOptions<UserManagementDBContext> options) : DbContext(options)
    {
        internal DbSet<Group> Groups { get; set; }
        internal DbSet<User> Users { get; set; }
        internal DbSet<Permission> Permissions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Users)
                .WithMany(g => g.Groups);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Permissions)
                .WithOne()
                .HasForeignKey(p => p.GroupId);
        }
    }
}
