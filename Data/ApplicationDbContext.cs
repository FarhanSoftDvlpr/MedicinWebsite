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
                UNIQUE INDEXES
            */

            modelBuilder.Entity<Role>()
                .HasIndex(x => x.RoleKey)
                .IsUnique();

            modelBuilder.Entity<Permission>()
                .HasIndex(x => x.PermissionKey)
                .IsUnique();

            modelBuilder.Entity<AdminUser>()
                .HasIndex(x => x.Email)
                .IsUnique();

            /*
                COMPOSITE KEYS
            */

            modelBuilder.Entity<RolePermission>()
                .HasKey(x => new
                {
                    x.RoleId,
                    x.PermissionId
                });

            modelBuilder.Entity<AdminUserRole>()
                .HasKey(x => new
                {
                    x.AdminUserId,
                    x.RoleId
                });
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is Common.BaseEntity &&
                    (
                        e.State == EntityState.Added ||
                        e.State == EntityState.Modified
                    ));

            foreach (var entityEntry in entries)
            {
                var entity = (Common.BaseEntity)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                else
                {
                    entity.UpdatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}