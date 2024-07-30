// See https://aka.ms/new-console-template for more information
using FoodieMenu.Data.MockDataService;
using FoodieMenu.Domain.Restaurants;
using FoodieMenu.Data.Repositories;

Restaurant newRestaurant = MockDataService.Restaurant;
IRestaurantRepository restaurantRepository = new RestaurantRepository();
restaurantRepository.AddRestaurant(newRestaurant);
Restaurant restaurant = restaurantRepository.GetRestaurantById(1);

Console.WriteLine("dkfj");
