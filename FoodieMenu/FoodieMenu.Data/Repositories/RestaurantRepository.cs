using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using FoodieMenu.Data.MockDataService;
using FoodieMenu.Domain.UserAuthentication;

namespace FoodieMenu.Data.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly FoodieContext _context;

        public RestaurantRepository()
        {
            _context = new FoodieContext();
            if (!_context.Restaurants.Any())
            {
                foreach (var restaurant in MockDataService.MockDataService.Restaurants)
                {
                    AddRestaurant(restaurant);
                }

                foreach (UserAccount user in MockDataService.MockDataService.Users)
                {
                    user.restaurants = GetAllRestaurant();
                }
            }
        }
        public void AddUser(UserAccount user)
        {
            _context.UserAccounts.Add(user);
            _context.SaveChanges();
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

        public List<Restaurant> GetAllRestaurant()
        {
            return _context.Restaurants.Include(x => x.Menus).Include(x => x.Items).ToList();
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

        public List<Item> GetItemsByCategoryID(int categoryID)
        {
            Category category = _context.Categories.Single(x => x.CategoryID == categoryID);
            if (category == null)
            {
                return new List<Item>();
            }
            return _context.Items.Where(x => x.Categories.Contains(category)).ToList();
        }

        public Menu GetMenuByID(int ID)
        {
            return PopulateMenu(_context.Menus.Include(x => x.Categories).Single(x => x.MenuID == ID));
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
            _context.SaveChanges();
        }

        public void RemoveMenu(Menu menu)
        {
            _context.Menus.Remove(menu);
            _context.SaveChanges();
        }

        public void RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void RemoveRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
        }

        private Menu PopulateMenu(Menu menu)
        {
            List<Item> restaurantItems = _context.Items.Where(x => x.RestaurantID == menu.RestaurantID).ToList();
            // Populate categories
            menu.Categories = _context.Categories.Include(x => x.Items).Where(x => x.MenuID == menu.MenuID).ToList();
            return menu;
        } 

        // Update

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            _context.SaveChanges();
        }
        public void UpdateMenu(Menu menu)
        {
            _context.Menus.Update(menu);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }
    }
}
