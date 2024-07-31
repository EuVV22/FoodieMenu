using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Web.Components.Pages
{
    public partial class AddRestaurant
    {
        [SupplyParameterFromForm]
        public string RestaurantName { get; set; }
        [SupplyParameterFromForm]
        public string RestaurantDescription { get; set; }
        [SupplyParameterFromForm]
        public string RestaurantEmail { get; set; }
        [Inject]
        IRestaurantRepository Repository {  get; set; }

        // TODO: don't allow restaurants with the same name
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        private bool CreateRestaurant()
        {
            Restaurant restaurant = new Restaurant()
            {
                Name = RestaurantName,
                Description = RestaurantDescription,
                email = RestaurantEmail
            };
            Repository.AddRestaurant(restaurant);
            return true;
        }
        private void SummitForm()
        {
            CreateRestaurant();
            Restaurant createdRestaurant = Repository.GetRestaurantByEmail(RestaurantEmail);
            NavManager.NavigateTo($"/AddMenu/{createdRestaurant.RestaurantID}");
        }
    }
}
