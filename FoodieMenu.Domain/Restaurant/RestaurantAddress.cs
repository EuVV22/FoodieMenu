using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Data.Entities
{
    internal class RestaurantAddress
    {
        public int AddressID { get; set; }
        public string AddressName { get; set; } = string.Empty;
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public Schedule Schedule { get; set; }
        public int RestaurantID { get; set; }

    }
}
