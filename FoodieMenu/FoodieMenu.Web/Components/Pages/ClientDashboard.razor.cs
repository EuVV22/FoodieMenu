namespace FoodieMenu.Web.Components.Pages
{
    public partial class ClientDashboard
    {
        const string seeItems = "/Items";
        const string seeRestaurants = "/RestaurantList";

        private void NavigationControl(string url)
        {
            NavManager.NavigateTo(url);
        }
    }
}
