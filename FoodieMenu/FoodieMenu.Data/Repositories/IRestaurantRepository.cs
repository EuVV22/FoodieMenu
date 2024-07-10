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
        void AddRestaurant(Restaurant restaurant);
        Restaurant GetRestaurantById(int ID);
        Restaurant GetRestaurantByEmail(string email);
        List<string> GetAllRestaurantEmails();
    }
}
