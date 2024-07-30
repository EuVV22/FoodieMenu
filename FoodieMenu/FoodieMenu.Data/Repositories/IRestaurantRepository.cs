using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Data.Repositories
{
    public interface IRestaurantRepository
    {
        public void AddRestaurant(Restaurant restaurant);
        public void AddAddress(AddressRestaurant address);
        public void AddMenu(Menu menu);
        public void AddCategory(Category category);
        public void AddItem(Item item);
        public Restaurant GetRestaurantById(int ID);
        public Restaurant GetRestaurantByEmail(string email);
        public List<string> GetAllRestaurantEmails();

        // Menu
        public List<Item> GetAllItems();
        public List<Item> GetItemsByRestaurantID(int ID);
        public List<AddressRestaurant> GetAddressRestaurantsByRestaurantID(int ID);
        public List<Menu> GetMenusByRestaurantID(int ID);

        // Delete
        public void RemoveItem(Item item);
        public void RemoveMenu(Menu menu);
        public void RemoveCategory(Category category);
        public void RemoveRestaurant(Restaurant restaurant);

        // Update
        public void UpdateMenu(Menu menu);
    }
}
