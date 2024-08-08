using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Web.Components.Pages.RestaurantDashboard
{
    public partial class RestaurantDashboard
    {
        [Parameter]
        public int RestaurantID { get; set; }
        [Inject]
        IRestaurantRepository repository { get; set; }
        private Restaurant restaurant { get; set; }
        private Dictionary<string, string> Paths {  get; set; }

        private string AddMenuPath { get; set; }
        private string AddItemPath { get; set; }
        private string MenusPath { get; set; }
        private string UpdateRestaurantPath { get; set; }

        protected override Task OnInitializedAsync()
        {
            restaurant = repository.GetRestaurantById(RestaurantID);

            AddMenuPath = $"/AddMenu/{RestaurantID}";
            AddItemPath = $"/AddItem/{RestaurantID}";
            MenusPath = $"/Menus/{RestaurantID}";
            UpdateRestaurantPath = $"/UpdateRestaurant/{RestaurantID}";

            return base.OnInitializedAsync();
        }
    }
}
