// See https://aka.ms/new-console-template for more information
using FoodieMenu.Data.MockDataService;
using FoodieMenu.Domain.Restaurants;
using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;

Restaurant newRestaurant = MockDataService.Restaurant;
Restaurant res1 = MockDataService.Restaurants[0];
IRestaurantRepository restaurantRepository = new RestaurantRepository();
//restaurantRepository.AddRestaurant(newRestaurant);
restaurantRepository.AddRestaurant(res1);

Restaurant restaurant = restaurantRepository.GetRestaurantById(1);

Console.WriteLine("dkfj");
