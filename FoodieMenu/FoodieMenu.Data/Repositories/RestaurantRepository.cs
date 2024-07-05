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

        public RestaurantRepository(FoodieContext context)
        {
            _context = context;
        }

        async Task AddRestaurantAsync(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
        }
        Task UpdateRestaurantAsync(Restaurant restaurant)
        {
        }
        public async Task<Restaurant> GetRestaurantByIdAsync(int ID)
        {
            return  _context.Restaurants.Single(x => x.RestaurantID == ID);
        }
        Task GetRestaurantByEmailAsync(string email);
    }
}
