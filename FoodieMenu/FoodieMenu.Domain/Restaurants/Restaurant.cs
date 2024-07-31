using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieMenu.Domain.Menu;

namespace FoodieMenu.Domain.Restaurants
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string email { get; set; }
        public List<Menu.Menu> Menus { get; set; }
        public List<Item> Items { get; set; }
        public List<AddressRestaurant> Address { get; set;}

        public Restaurant()
        {
            Menus = [];
            Items = [];
            Address = [];
        }
    }
}
