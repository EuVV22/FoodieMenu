// See https://aka.ms/new-console-template for more information
using FoodieMenu.Data.MockDataService;
using FoodieMenu.Domain.Restaurants;
using FoodieMenu.Data.Repositories;


IRestaurantRepository restaurantRepository = new RestaurantRepository();
Restaurant restaurant = restaurantRepository.GetRestaurantById(1);

Console.WriteLine("dkfj");
