using Microsoft.EntityFrameworkCore;
using PSIUWeb.Models;

namespace PSIUWeb.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Patients?.Any() ?? false)
            {
                context.Patients?.AddRange(
                    new Patient
                    {
                        Name = "Mauro",
                        BirthDate = new DateTime(1984, 7, 5),
                        Ethnicity = Ethnicity.Pardo,
                        Height = 180,
                        Weight = 88
                    },
                    new Patient
                    {
                        Name = "Marcos",
                        BirthDate = new DateTime(1987, 2, 28),
                        Ethnicity = Ethnicity.Pardo,
                        Height = 175,
                        Weight = 90
                    }
                );

                context.SaveChanges();
            }
        }

    }
}
