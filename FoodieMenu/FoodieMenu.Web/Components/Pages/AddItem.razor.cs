using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Web.Components.Pages
{
    public partial class AddItem
    {
        [Parameter]
        public int RestaurantID { get; set; }
        private Restaurant _restaurant { get; set; }
        private IRestaurantRepository Repository { get; set; }
        private string SelectedMenu {  get; set; } = string.Empty;
        protected override Task OnInitializedAsync()
        {
            Repository = new RestaurantRepository();
            _restaurant = Repository.GetRestaurantById(RestaurantID);
            return base.OnInitializedAsync();
        }

        private string MenuName { get; set; }
        private string CategoryName { get; set; }
        private string SubcategoryName { get; set; }

        private Menu CreateMenu()
        {;
            Category category = new Category() { Name = CategoryName };
            return new Menu() { Name = MenuName, Categories = [category] };
        }

        private string CategorySelected {  get; set; }
    }
}
