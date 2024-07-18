using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;

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
        public string SubcategoryName { get; set; }
        [SupplyParameterFromForm]
        public string ItemName { get; set; }
        [SupplyParameterFromForm]
        public string ItemDescription { get; set; }
        [SupplyParameterFromForm]
        public double ItemPrice { get; set; }


        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async Task OnSubmit()
        {
            Restaurant restaurant = new Restaurant()
            {
                Name = RestaurantName,
                Description = RestaurantDescription,
                email = RestaurantEmail
            };
            Menu menu = new Menu() { Name = MenuName };
            Category category = new Category() { Name = CategoryName };
            Subcategory subcategory = new Subcategory() { Name = SubcategoryName };
            Item item = new Item()
            {
                Name = ItemName,
                Description = ItemDescription,
                Price = ItemPrice,
                IsActive = true
            };
            subcategory.Items = [item];
            category.Subcategories = [subcategory];
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
