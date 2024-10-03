using FoodieMenu.Data.Repositories;
using FoodieMenu.Domain.Menu;
using Microsoft.AspNetCore.Components;

namespace FoodieMenu.Web.Components.Pages
{
    public partial class DisplayItems
    {
        [Inject]
        private HttpClient _httpClient { get; set; }
        [Inject]
        IRestaurantRepository Repository { get; set; }
        private List<Item> items { get; set; }

        private List<Item> tt = new List<Item>();

        
        protected override Task OnInitializedAsync()
        {
            items = Repository.GetAllItems();
            //CallingTheAPI();
            return base.OnInitializedAsync();

        }

        public async void CallingTheAPI()
        {
            var resp = await _httpClient.GetAsync("https://localhost:7218/api/Item");
            string content = await resp.Content.ReadAsStringAsync();
            return;
        }
    }
}
