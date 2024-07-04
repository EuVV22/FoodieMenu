using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Menu
{
    public class Menu
    {
        public int RestaurantID { get; set; }
        public int MenuID { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
        public bool IsActive { get; set; }
    }
}
