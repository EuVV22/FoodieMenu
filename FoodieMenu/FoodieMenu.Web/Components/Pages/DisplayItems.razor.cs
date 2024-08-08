using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Web.Components.Pages
{
    public partial class DisplayItems
    {
        [Inject]
        IRestaurantRepository Repository { get; set; }
        private List<Item> items { get; set; }
        
        protected override Task OnInitializedAsync()
        {
            items = Repository.GetAllItems();
            return base.OnInitializedAsync();
        }

    }
}
