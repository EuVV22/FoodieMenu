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
        public static List<Restaurant> Restaurants
        {
            get
            {
                return [Barc(), Restaurant] ;
            }
        }

        // Barcelona
        private static Restaurant Barc()
        {
            Restaurant result = new Restaurant()
            {
                Name = "Barcelona",
                Description = "Bistro bar",
                email = "barcelona@barcelona.com",
                Address = [BarcAddress()],
                Menus = [BarcMenu()],
            };
            foreach (Category category in result.Menus[0].Categories)
            {
                foreach (Item item in category.Items)
                {
                    result.Items.Add(item);
                }
            }
            return result;
        }

        private static AddressRestaurant BarcAddress()
        {
            return new AddressRestaurant()
            {
                AddressName = "J Town",
                Street = "10415 Taylorsville Rd",
                City = "Louisville",
                PostalCode = "40299",
                Region = "Kentucky"
            };
        }

        private static Menu BarcMenu()
        {
            return new Menu()
            {
                Name = "Main menu",
                IsActive = true,
                Categories = BarcCategories()
            };
        }

        private static List<Category> BarcCategories()
        {
            Category category1 = new Category() { Name = "Tapas", Items = BarcTapasItems() };
            Category category2 = new Category() { Name = "Entrees", Items = BarcEntreesItems() };
            Category category4 = new Category() { Name = "Desserts", Items = BarcDessertsItems() };
            return [category1, category2, category4];
        }

        private static List<Item> BarcTapasItems()
        {
            Item item1 = new Item()
            {
                Name = "Spanish Serrano Ham Croquettes",
                Description = "5 Creamy and crispy Serrano ham croquettes. Served with seasoned French Fries.",
                Price = 16.90
            };
            Item item2 = new Item()
            {
                Name = "Fried Spanish Chistorra",
                Description = "Spanish fast-cured sausage. Served with baguette bread.",
                Price = 7.5
            };
            Item item3 = new Item()
            {
                Name = "Bomba De Carne",
                Description = "Minced veal interior and spicy chorizo breaded in potato and fried with allioli on top.. Served over sautéed vegetables.",
                Price = 12.5
            };
            return [item1, item2, item3];
        }

        private static List<Item> BarcEntreesItems()
        {
            Item item1 = new Item()
            {
                Name = "Lasagna Bolognese",
                Description = "BBB lasagna recipe layered with a mix of hearty ragù bolognese (slow-cooked meat sauce) and creamy béchamel (white sauce) with melting cheese; served with salad (Olive Oil and Salt).",
                Price = 18.90
            };
            Item item2 = new Item()
            {
                Name = "Crepe",
                Description = "Homemade Crêpe stuffed with broiled chicken, pork and beef over a tomato sauce covered with bechamel & cheese and Garlic Mushrooms on the side. ",
                Price = 19.9
            };
            Item item3 = new Item()
            {
                Name = "Mussels in cream sauce",
                Description = "Mussels (Belgium style) red onion, celery, mediterranean herbs, white wine, wip cream and parsley",
                Price = 14.5
            };
            return [item1, item2, item3];
        }

        private static List<Item> BarcDessertsItems()
        {
            Item item1 = new Item()
            {
                Name = "Beignet ",
                Description = "Deep fried beignet with pecan ice cream and glaze nuts. Indulge yourself!",
                Price = 9
            };
            Item item2 = new Item()
            {
                Name = "Catalan Cream",
                Description = "Typical catalan dessert similar to Crème Brûlée but infused with citrus & cinnamon with a crunchy burnt caramel on the surface. It is served cold.",
                Price = 8
            };
            Item item3 = new Item()
            {
                Name = "Churros with Chocolate",
                Description = "Homemade Spanish Churros with “Chocolate a la Taza” (hot thick chocolate).",
                Price = 9
            };
            return [item1, item2, item3];
        }


        // Res2 TODO: Add more restaurants

        public static Restaurant Restaurant
        {
            get
            {
                Restaurant result = InitializeMockRestaurants()[0];
                result.Address = InitializeRestaurantAddress();
                result.Menus = InitilizeMockMenus();
                result.Items = result.Menus[0].Categories[0].Items;
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
                IsActive = true,
                Name = "SummerMenu",
                Categories = InitializeMockCategories(),
            }];
        }

        private static List<Category> InitializeMockCategories()
        {
            Category category1 = new Category()
            {
                Name = "Appetizers",
                Items = InitilizeMockItems()
            };
            Category category2 = new Category()
            {
                Name = "Entrees",
                Items = []
            };
            return [category1, category2];
        }

        public static List<Item> InitilizeMockItems()
        {
            Item item1 = new Item()
            {
                Name = "Arepa",
                Description = "Venezuelan typical food made out of cornmeal and stuff.",
                Price = 7.5,
                IsActive = true
            };
            Item item2 = new Item()
            {
                Name = "Cachapa",
                Description = "Flat yellow sweet corn base pancake stuff with cheese",
                Price = 8.8,
                IsActive = true
            };
            return [item1, item2];
        }
    }
}
