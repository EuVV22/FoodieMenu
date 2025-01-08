using Microsoft.AspNetCore.Components;
using FoodieMenu.Data.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace FoodieMenu.Web.Components.Pages.Account
{
    public partial class LogIn
    {
        [CascadingParameter]
        public HttpContext? _httpContext { get; set; }
        [Inject]
        public IRestaurantRepository repository { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public async Task Authenticate()
        {
            var userAccount = repository.GetUserByUserName(UserName);
            if (userAccount == null || userAccount.Password != Password)
            {
                return;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, UserName),
                new Claim(ClaimTypes.Role, userAccount.Role)
            };
            
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await _httpContext.SignInAsync(principal);

            NavManager.NavigateTo("/");

        }
    }
}
