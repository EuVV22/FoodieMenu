using FoodieMenu.Data;
using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Web.Components.Pages.RestaurantDashboard
{
    public partial class UpdateRestaurant
    {
        [Parameter]
        public int RestaurantID { get; set; }
        [Inject]
        IRestaurantRepository repository { get; set; }
        private Restaurant restaurant { get; set; }
        private FoodieContext context { get; set; }

        protected override Task OnInitializedAsync()
        {
            restaurant = repository.GetRestaurantById(RestaurantID);

            
            return base.OnInitializedAsync();
        }

        private void UpdateRestaurantInfo()
        {
            repository.UpdateRestaurant(restaurant);
            NavManager.NavigateTo($"/RestaurantDashboard/{RestaurantID}");
        }
    }
}
