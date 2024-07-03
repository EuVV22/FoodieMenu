using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Menu
{
    internal class Menu
    {
        int RestaurantID { get; set; }
        int MenuID { get; set; }
        string Name { get; set; }
        List<Category> Categories { get; set; }
        bool IsActive { get; set; }
    }
}
