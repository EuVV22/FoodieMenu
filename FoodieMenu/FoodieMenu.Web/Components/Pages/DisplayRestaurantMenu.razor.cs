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
        private Restaurant restaurant { get; set; }
        protected override Task OnInitializedAsync()
        {
            menu = repository.GetMenuByID(MenuID);
            restaurant = repository.GetRestaurantById(menu.RestaurantID);
            return base.OnInitializedAsync();
        }

    }
}
