using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Menu
{
    public class Subcategory
    {
        public int CategoryID { get; set; }
        public int SubcategoryID { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }

    }
}
