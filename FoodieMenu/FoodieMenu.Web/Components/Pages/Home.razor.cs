﻿namespace FoodieMenu.Web.Components.Pages
{
    public partial class Home
    {

        const string RestaurantAppURL = "/RestaurantToAddItem";
        const string ClientAppURL = "/ClientDashboard";

        private void NavigateToApp(string url)
        {
            NavManager.NavigateTo(url);
        }
    }
}
