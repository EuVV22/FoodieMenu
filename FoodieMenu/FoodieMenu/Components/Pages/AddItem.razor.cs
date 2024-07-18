
using FoodieMenu.Data;
using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Components.Pages
{
    public partial class AddItem
    {
        [Parameter]
        public int RestaurantID { get; set; }
        private Restaurant _restaurant { get; set; }
        private IRestaurantRepository Repository { get; set; }
        protected override Task OnInitializedAsync()
        {
            Repository = new RestaurantRepository();
            _restaurant = Repository.GetRestaurantById(RestaurantID);
            return base.OnInitializedAsync();
        }
    }
}
