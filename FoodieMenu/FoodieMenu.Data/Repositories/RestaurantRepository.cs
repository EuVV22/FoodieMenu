using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Data.Repositories
{
    internal class RestaurantRepository : IRestaurantRepository
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
        public Restaurant GetRestaurantById(int ID)
        {
            return  _context.Restaurants.Single(x => x.RestaurantID == ID);
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


    }
}
