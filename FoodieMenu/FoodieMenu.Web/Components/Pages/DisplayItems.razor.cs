using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Web.Components.Pages
{
    public partial class DisplayItems
    {
        private List<Item> items { get; set; }
        [Inject]
        IRestaurantRepository Repository { get; set; }
        protected override Task OnInitializedAsync()
        {
            items = Repository.GetAllItems();
            return base.OnInitializedAsync();
        }

    }
}
