using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Web.Components.Pages.RestaurantDashboard
{
    public partial class ChooseMenu
    {
        [Parameter]
        public int RestaurantID { get; set; }

        [Inject]
        IRestaurantRepository repository { get; set; }
        List<Menu> menus { get; set; }
        protected override Task OnInitializedAsync()
        {
            menus = repository.GetMenusByRestaurantID(RestaurantID);

            return base.OnInitializedAsync();
        }

        private void NavigateToEditMenuPage(int MenuID)
        {
            NavManager.NavigateTo($"/UpdateMenu/{MenuID}");
        }
    }
}
