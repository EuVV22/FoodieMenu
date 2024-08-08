using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Web.Components.Pages
{
    public partial class DisplayRestaurantMenu
    {
        [Parameter]
        public int MenuID { get; set; }
        [Inject]
        IRestaurantRepository repository { get; set; }
        private Menu menu { get; set; }
        private string restaurantName { get; set; }
        protected override Task OnInitializedAsync()
        {
            menu = repository.GetMenuByID(MenuID);
            Restaurant restaurant = repository.GetRestaurantById(menu.RestaurantID);
            restaurantName = restaurant.Name;
            return base.OnInitializedAsync();
        }

    }
}
