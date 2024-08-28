using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ProHardikV1.Authorization.Roles;
using ProHardikV1.Authorization.Users;
using ProHardikV1.MultiTenancy;
using Abp.Localization;
using ProHardikV1.Models;

namespace ProHardikV1.EntityFrameworkCore
{
    public class ProHardikV1DbContext : AbpZeroDbContext<Tenant, Role, User, ProHardikV1DbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ProHardikV1DbContext(DbContextOptions<ProHardikV1DbContext> options)
            : base(options)
        {
        }

        // add these lines to override max length of property
        // we should set max length smaller than the PostgreSQL allowed size (10485760)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100); // any integer that is smaller than 10485760
        }
        public virtual DbSet<Student> Students { get; set; }
    }
}
