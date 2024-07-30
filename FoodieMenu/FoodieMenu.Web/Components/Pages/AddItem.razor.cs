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
        private Menu menu { get; set; }
        private Category category { get; set; }
        private Item item { get; set; }

        protected override Task OnInitializedAsync()
        {
            Repository = new RestaurantRepository();
            _restaurant = Repository.GetRestaurantById(RestaurantID);
            item = new Item();
            return base.OnInitializedAsync();
        }

        private string MenuName { get; set; }
        private string CategoryName { get; set; }
        private string SelectedCategory { get; set; }

        private const string NewMenu = "New menu";
        private const string NewCategory = "New category";


        private void CreateMenu()
        {;
            if (SelectedMenu == NewMenu)
            {
                // TODO: Don't allow duplication on menu names
                _restaurant.Menus.Add(new Menu { Name = MenuName });
            }

            menu = _restaurant.Menus.First(x => x.Name == SelectedMenu);
        }

        private void CreateCategory()
        {
            if (SelectedMenu == NewMenu || SelectedCategory == NewCategory)
            {
                menu.Categories.Add(new Category { Name = CategoryName });
            }
            category = menu.Categories.First(x => x.Name == SelectedCategory);
        }
        private void summit()
        {
            CreateMenu();
            CreateCategory();
            category.Items.Add(item);
            menu.Categories.Add(category);

            _restaurant.Items.Add(item);

            if (SelectedMenu == NewMenu)
            {
                Repository.AddMenu(menu);
            } else
            {
                Repository.UpdateMenu(menu);
            }

            Repository.AddMenu(menu);
        }
    }
}
