using JobHuntApi.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobHuntApi.Models
{
    public class JobHuntApiDbContext : IdentityDbContext<User>
    {
        public JobHuntApiDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            
            modelBuilder.Entity<Application>()
                .HasMany(e => e.Interviews)
                .WithOne(e => e.Application)
                .HasForeignKey(e => e.ApplicationId)
                .IsRequired();

        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Interview> Interviews { get; set; }
    }
}