using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Models;

namespace PSIUWeb.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient>? Patients { get; set; }

        public DbSet<Psychologist>? Psychologists { get; set; }

        public DbSet<Address>? Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                    .HasOne(i => i.Psychologist)
                    .WithMany(a => a.Addresses)
                    .HasForeignKey(p => p.PsychologistId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
