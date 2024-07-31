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
        protected override Task OnInitializedAsync()
        {
            restaurant = repository.GetRestaurantById(RestaurantID);
            return base.OnInitializedAsync();
        }

        private void NavigateToAddMenu()
        {
            NavManager.NavigateTo($"/AddMenu/{RestaurantID}");
        }
        private void NavigateToAddItem()
        {
            NavManager.NavigateTo($"/AddItem/{RestaurantID}");
        }
        private void NavigateToUpdateRestaurant()
        {
            NavManager.NavigateTo($"/UpdateRestaurant/{RestaurantID}");
        }
    }
}
