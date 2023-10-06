using Microsoft.EntityFrameworkCore;
using PSIUWeb.Models;

namespace PSIUWeb.Data
{
    public static class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if(!context.Pacients.Any())
            {
                context.Pacients.AddRange(
                    new Pacient
                    {
                        Name = "Mauricio",
                        BirthDate = new DateTime(1984, 7, 5),
                        Race = Race.Pardo,
                        Height = 180,
                        Weight = 88
                    },
                    new Pacient
                    {
                        Name = "Afonso",
                        BirthDate = new DateTime(1967, 7, 5),
                        Race = Race.Branco,
                        Height = 170,
                        Weight = 78
                    }
                );
                context.SaveChanges();
            }
            if (!context.Psicos.Any())
            {
                context.Psicos.AddRange(
                    new Psico
                    {
                        Name = "Leonardo",
                        BirthDate = new DateTime(1998, 4, 6),
                        Race = Race.Branco,
                        TimeWork = "7 Anos",
                        Graduation = "Psicologia, Unoesc - Videira"
                    },
                    new Psico
                    {
                        Name = "Pedro",
                        BirthDate = new DateTime(2000, 8, 2),
                        Race = Race.Negro,
                        TimeWork = "5 Anos",
                        Graduation = "Psicologia, Unoesc - Videira"
                    }
                    );

                context.SaveChanges();
            }
        }

    }
}
