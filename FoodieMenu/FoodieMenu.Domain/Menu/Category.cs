using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Menu
{
    internal class Category
    {
        int MenuID { get; set; }
        int CategoryID { get; set; }
        string Name { get; set; }
        List<Subcategory> Subcategories { get; set; }
    }
}
