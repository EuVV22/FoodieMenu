using FoodieMenu.Data.Repositories;
using FoodieMenu.Data;
using FoodieMenu.Domain.Restaurants;
using Microsoft.AspNetCore.Components;
using FoodieMenu.Domain.Menu;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace FoodieMenu.Web.Components.Pages.RestaurantDashboard
{
    public partial class UpdateMenu
    {
        [Parameter]
        public int MenuID { get; set; }
        [Inject]
        IRestaurantRepository repository { get; set; }
        private Restaurant restaurant { get; set; }
        private Menu menu { get; set; }
        private FoodieContext context { get; set; }

        private Dictionary<string, bool> EditItem {  get; set; }
        protected override Task OnInitializedAsync()
        {
            menu = repository.GetMenuByID(MenuID);
            EditItem = new Dictionary<string, bool>();
            foreach (Category category in menu.Categories)
            {
                foreach (Item item in category.Items)
                {
                    EditItem.Add(item.Name, false);
                }
            }
            return base.OnInitializedAsync();
        }

        private void DeleteCategory(int categoryID)
        {
            return;
        }
        private void UpdateItem(int ItemID)
        {
            
        }
    }
}
