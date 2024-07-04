using FoodieMenu.Domain.Menu;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Components.Pages
{
    public partial class DefineMenu
    {
        [Parameter]
        public string MenuName { get; set; }
        public Menu Menu { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public Item Item { get; set; }
        protected override void OnInitialized()
        {
            Menu = new Menu();
            Menu.Name = MenuName;
            Category = new Category();
            base.OnInitialized();
        }

        private async Task OnSubmit()
        {
            /// Pass data
        }
    }
}
