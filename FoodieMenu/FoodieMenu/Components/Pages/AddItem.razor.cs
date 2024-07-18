
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Components.Pages
{
    public partial class AddItem
    {
        [Parameter]
        public int RestaurantID { get; set; }
        protected override Task OnInitializedAsync()
        {
            
            return base.OnInitializedAsync();
        }
    }
}
