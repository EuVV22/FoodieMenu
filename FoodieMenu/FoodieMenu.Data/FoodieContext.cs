﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieMenu.Domain.Restaurants;
using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Clients;
using FoodieMenu.Domain.UserAuthentication;
using Microsoft.Extensions.Options;

namespace FoodieMenu.Data
{
    public class FoodieContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<AddressRestaurant> Address {  get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public string DbPath { get; }

        public FoodieContext()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).FullName;
            var path = Directory.GetParent(projectDirectory).FullName;
            DbPath = System.IO.Path.Join(projectDirectory, "Foodie.db");
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}
