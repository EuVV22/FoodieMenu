using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FoodieMenu.Domain.Restaurant;


namespace FoodieMenu.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            public DbSet<Restaurant> Restaurants { get; set; }
            public DbSet<>

        }
    }
}
