using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Web.Components.Pages
{
    public partial class DisplayAllRestaurants
    {
        [Inject]
        IRestaurantRepository repository {  get; set; }
        List<Restaurant> AllRestaurants { get; set; }
        List<Menu> menus { get; set; }
        int RestaurantClickedOn { get; set; }

        protected override Task OnInitializedAsync()
        {
            AllRestaurants = repository.GetAllRestaurant();
            return base.OnInitializedAsync();
        }

        private void DisplayRestaurantMenus(int restaurantID)
        {
            Restaurant restaurant = repository.GetRestaurantById(restaurantID);
            menus = restaurant.Menus;
            RestaurantClickedOn = restaurantID;
        }

        private void NavigateToRestaurantMenu(int menuID)
        {

            NavManager.NavigateTo($"/menu/{menuID}");
        }
    }
}
