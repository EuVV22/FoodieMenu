using FoodieMenu.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Data.Repositories
{
    public interface IRestaurantRepository
    {
        Task AddRestaurantAsync(Restaurant restaurant);
        Task UpdateRestaurantAsync(Restaurant restaurant);
        Task GetRestaurantByIdAsync(int ID);
        Task GetRestaurantByEmailAsync(string email);
    }
}
