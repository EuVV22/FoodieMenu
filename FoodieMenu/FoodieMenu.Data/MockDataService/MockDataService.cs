using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Data.MockDataService
{
    public class MockDataService
    {
        private static List<AddressRestaurant> _addresses { get; set; }
        public static List<Restaurant> Restaurants { get; set; }
        public static Restaurant Restaurant
        {
            get
            {
                Restaurant result = InitializeMockRestaurants()[0];
                result.Address = InitializeRestaurantAddress();
                result.Menus = InitilizeMockMenus();
                result.Items = result.Menus[0].Categories[0].Subcategories[0].Items;
                return result;
            }
        }
        private static List<Item> _items { get; set; }

        private static List<AddressRestaurant> InitializeRestaurantAddress()
        {
            AddressRestaurant restaurant1 = new AddressRestaurant()
            {
                AddressName = "Campus",
                Street = "762 S 1st St",
                City = "Louisville",
                PostalCode = "40202",
                Phone = "5022135333"
            };
            AddressRestaurant restaurant2 = new AddressRestaurant()
            {
                AddressName = "Churchill",
                Street = "700 Central Ave",
                City = "Louisville",
                PostalCode = "40208",
                Phone = "5026364400"
            };
            return [restaurant1, restaurant2];
        }
        private static List<Restaurant> InitializeMockRestaurants()
        {
            Restaurant restaurant1 = new Restaurant()
            {
                RestaurantID = 1,
                Name = "ResCode",
                Description = "Mock restaurant with address of the campus",
                email = "rescode@example.com"
            };
            return [restaurant1];
        }

        private static List<Menu> InitilizeMockMenus()
        {
            return [new Menu()
            {
                MenuID = 1,
                RestaurantID = 1,
                IsActive = true,
                Name = "SummerMenu",
                Categories = InitializeMockCategories(),

            }];
        }

        private static List<Category> InitializeMockCategories()
        {
            Category category1 = new Category()
            {
                MenuID = 1,
                CategoryID = 1,
                Name = "Appetizers",
                Subcategories = InitializeMockSubcategories()
            };
            Category category2 = new Category()
            {
                MenuID = 2,
                CategoryID = 2,
                Name = "Entrees",
                Subcategories = []
            };
            return [category1, category2];
        }

        private static List<Subcategory> InitializeMockSubcategories()
        {
            Subcategory subcategory1 = new Subcategory()
            {
                CategoryID = 1,
                SubcategoryID = 1,
                Name = "Venezuelan app",
                Items = InitilizeMockItems()
            };
            return [subcategory1];
        }

        private static List<Item> InitilizeMockItems()
        {
            Item item1 = new Item()
            {
                RestaurantID = 1,
                ItemID = 1,
                Name = "Arepa",
                Description = "Venezuelan typical food made out of cornmeal and stuff.",
                Price = 7.5,
                IsActive = true
            };
            Item item2 = new Item()
            {
                RestaurantID = 1,
                ItemID = 2,
                Name = "Cachapa",
                Description = "Flat yellow sweet corn base pancake stuff with cheese",
                Price = 8.8,
                IsActive = true
            };
            return [item1, item2];
        }
    }
}
