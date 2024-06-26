using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Menu
{
    internal class SubCategory
    {
        public int SubCategoryID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public int RestaurantID { get; set; }
        public List<Item> Items { get; set; }
    }
}
