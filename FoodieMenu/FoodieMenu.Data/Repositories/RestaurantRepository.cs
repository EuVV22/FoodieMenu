using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Data.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly FoodieContext _context;

        public RestaurantRepository()
        {
            _context = new FoodieContext();
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }

        public void AddAddress(AddressRestaurant address)
        {
            _context.Address.Add(address);
            _context.SaveChanges();
        }

        public void AddMenu(Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void AddSubcategory(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
            _context.SaveChanges();
        }

        public void AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
        public Restaurant GetRestaurantById(int ID)
        {
            Restaurant restaurant = _context.Restaurants.Single(x => x.RestaurantID == ID);
            restaurant.Address = GetAddressRestaurantsByRestaurantID(ID);
            restaurant.Menus = GetMenusByRestaurantID(ID);
            restaurant.Items = GetItemsByRestaurantID(ID);
            return restaurant;
        }
        public Restaurant GetRestaurantByEmail(string email)
        {
            return _context.Restaurants.Single(restaurant => restaurant.email ==  email);
        }

        public List<string>GetAllRestaurantEmails()
        {
            return _context.Restaurants.Select(x => x.email).ToList();
        }

        // Menu

        public List<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public List<Item> GetItemsByRestaurantID(int ID)
        {
            return _context.Items.Where(x => x.RestaurantID == ID).ToList();
        }

        public List<AddressRestaurant> GetAddressRestaurantsByRestaurantID(int ID)
        {
            return _context.Address.Where(x => x.RestaurantID == ID).ToList();
        }

        public List<Menu> GetMenusByRestaurantID(int ID)
        {
            List<Menu> menus = _context.Menus.Where(x => x.RestaurantID == ID).ToList();
            foreach (Menu menu in menus)
            {
                PopulateMenu(menu);
            }
            return menus;
        }

        // Delete
        public void RemoveItem(Item item)
        {
            _context.Items.Remove(item);
        }

        public void RemoveMenu(Menu menu)
        {
            _context.Menus.Remove(menu);
        }

        public void RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        private void PopulateMenu(Menu menu)
        {
            List<Item> restaurantItems = _context.Items.Where(x => x.RestaurantID == menu.RestaurantID).ToList();
            // Populate categories
            menu.Categories = _context.Categories.Where(x => x.MenuID == menu.MenuID).ToList();

            // TODO: Maybe turn it into Eager Loading??
            // Populate subcategories
            foreach (var category in menu.Categories)
            {
                category.Subcategories = _context.Subcategories.Include(x => x.Items).Where(x => x.CategoryID == category.CategoryID).ToList();
            }
        } 


    }
}
