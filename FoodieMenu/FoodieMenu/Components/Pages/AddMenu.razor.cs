using FoodieMenu.Domain.Menu;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Components.Pages
{
    public partial class AddMenu
    {
        [SupplyParameterFromForm]
        public string Name { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async Task OnSubmit()
        {
            NavManager.NavigateTo($"/createmenu/{Name}");
        }
    }
}
