using CRUD_Pages.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Pages.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<Sublocation> Sublocations { get; set; } = null!;
    }
}