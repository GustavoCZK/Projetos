using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PjGustavoConte.Models;

namespace PjGustavoConte.Data
{
    public class AppDbContext :
        IdentityDbContext<AppPsico>
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Psicologo>? Psicologos { get; set; }

    }
}
