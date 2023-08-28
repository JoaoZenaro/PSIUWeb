using Microsoft.EntityFrameworkCore;

namespace PSIUWeb.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Patient>? Patients { get; set; }

}
