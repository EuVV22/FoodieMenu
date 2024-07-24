using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace FoodieMenu.Web.Components.Pages
{
    public partial class AddMenu
    {
        [SupplyParameterFromForm]
        public string RestaurantName { get; set; }
        [SupplyParameterFromForm]
        public string RestaurantDescription { get; set; }
        [SupplyParameterFromForm]
        public string RestaurantEmail { get; set; }
        [SupplyParameterFromForm]
        public string MenuName { get; set; }
        [SupplyParameterFromForm]
        public string CategoryName { get; set; }
        [SupplyParameterFromForm]
        public string ItemName { get; set; }
        [SupplyParameterFromForm]
        public string ItemDescription { get; set; }
        [SupplyParameterFromForm]
        public double ItemPrice { get; set; }
        public bool IsActive { get; set; } = true;

        MudForm form;
        bool success;
        string[] errors;

        protected override Task OnInitializedAsync()
        {
            IsActive = true;
            return base.OnInitializedAsync();
        }

        private async Task Test()
        {
            Restaurant restaurant = new Restaurant()
            {
                Name = RestaurantName,
                Description = RestaurantDescription,
                email = RestaurantEmail
            };
            Menu menu = new Menu() { Name = MenuName };
            Category category = new Category() { Name = CategoryName };
            Item item = new Item()
            {
                Name = ItemName,
                Description = ItemDescription,
                Price = ItemPrice,
                IsActive = true
            };
            category.Items = [item];
            menu.Categories = [category];
            restaurant.Menus = [menu];
            restaurant.Items = [item];

            RestaurantRepository repo = new RestaurantRepository();
            repo.AddRestaurant(restaurant);

            Restaurant addedRestaurant = repo.GetRestaurantByEmail(restaurant.email);
            NavManager.NavigateTo($"/AddItem/{addedRestaurant.RestaurantID}");
        }
    }
}
