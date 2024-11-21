using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodieMenu.Domain.Restaurants;

namespace FoodieMenu.Domain.UserAuthentication
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public List<Restaurant> restaurants { get; set; }
    }
}
