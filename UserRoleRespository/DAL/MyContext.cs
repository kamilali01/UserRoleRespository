using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using UserRoleModel.Entities;

namespace UserRoleModel.DAL
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options): base(options)
        {
            
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Permission>().HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<Role>()
        .HasMany(r => r.Permissions)
        .WithMany(p => p.Roles)
        .UsingEntity<Dictionary<string, object>>(
            "RolePermission", // Junction table name
            rp => rp.HasOne<Permission>().WithMany().HasForeignKey("PermissionId"),
            rp => rp.HasOne<Role>().WithMany().HasForeignKey("RoleId")
        );

            modelBuilder.Entity<Permission>().HasData(
                new Permission()
                {
                    Id = 1,
                    Name = "add",
                    Description = "add"
                },
                new Permission()
                {
                    Id = 2,
                    Name = "update",
                    Description = "update"
                },
                new Permission()
                {
                    Id = 3,
                    Name = "read",
                    Description = "read"
                }
            );
        }
    }
}
