using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Menu
{
    internal class Menu
    {
        public int MenuID { get; set; }
        public List<Category> Categories { get; set; }
        public int RestaurantID { get; set; }
        
    }
}
