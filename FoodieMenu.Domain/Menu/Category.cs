using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Menu
{
    internal class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public int RestaurantID { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
