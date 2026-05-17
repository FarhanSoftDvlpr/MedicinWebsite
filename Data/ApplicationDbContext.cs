using MEDICINE.WEB.Models;
using MEDICINE.WEB.Models.Admin;
using Microsoft.EntityFrameworkCore;

namespace MEDICINE.WEB.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) : base(options)
        {

        }

        public DbSet<AdminUser> AdminUsers { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<AdminUserRole> AdminUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
                ROLE UNIQUE KEY
            */

            modelBuilder.Entity<Role>()
                .HasIndex(x => x.RoleKey)
                .IsUnique();

            /*
                PERMISSION UNIQUE KEY
            */

            modelBuilder.Entity<Permission>()
                .HasIndex(x => x.PermissionKey)
                .IsUnique();

            /*
                ROLE PERMISSION COMPOSITE KEY
            */

            modelBuilder.Entity<RolePermission>()
                .HasKey(x => new
                {
                    x.RoleId,
                    x.PermissionId
                });

            /*
                ADMIN USER ROLE COMPOSITE KEY
            */

            modelBuilder.Entity<AdminUserRole>()
                .HasKey(x => new
                {
                    x.AdminUserId,
                    x.RoleId
                });
        }
    }
}