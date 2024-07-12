using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieMenu.Domain.Restaurants;
using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Clients;
using Microsoft.Extensions.Options;

namespace FoodieMenu.Data
{
    public class FoodieContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<AddressRestaurant> Address {  get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Client> Clients { get; set; }
        public string DbPath { get; }

        public FoodieContext()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).FullName;
            var path = Environment.CurrentDirectory;
            DbPath = System.IO.Path.Join(projectDirectory, "Foodie.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source=C:\\Users\\Euclides\\Documents\\Projects\\FoodieMenu\\FoodieMenu\\Foodie.db");
    }
}
