using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;

namespace FoodieMenu.Web.Components.Pages
{
    public partial class DisplayItems
    {
        private List<Item> items { get; set; }
        IRestaurantRepository Repository { get; set; }
        protected override Task OnInitializedAsync()
        {
            Repository = new RestaurantRepository();
            items = Repository.GetAllItems();
            return base.OnInitializedAsync();
        }

    }
}
