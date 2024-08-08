using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Text.RegularExpressions;

namespace FoodieMenu.Web.Components.Pages
{
    public partial class AddMenu
    {
        [Parameter]
        public int RestaurantID { get; set; }
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
        private bool areValuesValid { get; set; }

        Restaurant restaurant { get; set; }
        [Inject]
        IRestaurantRepository Repository { get; set; }
        public bool IsActive { get; set; } = true;

        MudForm form;
        bool success;
        string[] errors;

        protected override Task OnInitializedAsync()
        {
            restaurant = Repository.GetRestaurantById(RestaurantID);
            IsActive = true;
            return base.OnInitializedAsync();
        }

        private async Task Test()
        {
            
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

            Repository.UpdateRestaurant(restaurant);
            Restaurant addedRestaurant = Repository.GetRestaurantByEmail(restaurant.email);
            NavManager.NavigateTo($"/AddItem/{addedRestaurant.RestaurantID}");
        }

        private IEnumerable<string> MenuNameValidation(string newMenuName)
        {
            if (string.IsNullOrWhiteSpace(newMenuName))
            {
                yield return "Menu name is required!";
                yield break;
            }
            bool menuExists = restaurant.Menus.Any(x => x.Name == newMenuName);
            if (menuExists)
            {
                yield return "Menu name already exists for this restaurant.";
                yield break;
            }
            if (CheckIfStartOfTheStringIsInvalid(newMenuName))
            {
                yield return "Name can't start with an empty character.";
                yield break ;
            }
            if (ContainsLineBreak(newMenuName))
            {
                yield return "Line breaks are not allowed";
                yield break;
            }
        }

        public bool CheckIfStartOfTheStringIsInvalid(string s)
        {
            // Regex req
            bool result = Regex.IsMatch(s, @"^\s.+");
            return result;
        }

        public bool ContainsLineBreak(string s)
        {
            bool result = Regex.IsMatch(s, @"\n");
            return result;
        }
    }
}
