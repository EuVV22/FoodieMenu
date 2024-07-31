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
        IRestaurantRepository repository { get; set; }
        private Restaurant restaurant { get; set; }
        private FoodieContext context { get; set; }
        private string NewName { get; set; }
        private string NewDescription { get; set; } = string.Empty;
        private string NewEmail { get; set; }


        private string NewAddressName { get; set; }
        private string NewStreet { get; set; }
        private string NewCity { get; set; }
        private string NewRegion { get; set; }
        private string NewPostalCode { get; set; }
        private string NewPhone { get; set; }

        protected override Task OnInitializedAsync()
        {
            repository = new RestaurantRepository();
            restaurant = repository.GetRestaurantById(RestaurantID);

            
            return base.OnInitializedAsync();
        }

        private void UpdateRestaurantInfo()
        {
            repository.UpdateRestaurant(restaurant);
        }
    }
}
