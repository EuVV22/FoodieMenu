using MudBlazor;
using Microsoft.AspNetCore.Components;
using FoodieMenu.Domain.Restaurants;
using FoodieMenu.Data;
using FoodieMenu.Data.Repositories;

namespace FoodieMenu.Web.Components.Pages
{
    public partial class GetRestaurantName
    {
        private MudForm form2;

        [SupplyParameterFromForm]
        string RestaurantEmail { get; set; }
        Restaurant restaurant {  get; set; }
        [Inject]
        IRestaurantRepository repository { get; set; }

        private void ShowAddItemWeb()
        {
            restaurant = repository.GetRestaurantByEmail(RestaurantEmail);
            NavManager.NavigateTo($"/AddItem/{restaurant.RestaurantID}");
        }
    }
}
