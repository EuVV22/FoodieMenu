using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Web.Components.Pages.RestaurantDashboard
{
    public partial class RestaurantDashboard
    {
        [Parameter]
        public int RestaurantID { get; set; }
        IRestaurantRepository repository { get; set; }
        private Restaurant restaurant { get; set; }
        protected override Task OnInitializedAsync()
        {
            repository = new RestaurantRepository();
            restaurant = repository.GetRestaurantById(RestaurantID);
            return base.OnInitializedAsync();
        }
    }
}
