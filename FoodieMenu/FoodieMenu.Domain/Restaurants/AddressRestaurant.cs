using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Restaurants
{
    public class AddressRestaurant
    {
        [Required]
        [Key]
        public int AddressID { get; set; }

        [Required]
        public string AddressName { get; set; } = string.Empty;
        [Required]
        public string Street { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        [Required]
        public string PostalCode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        //public Schedule Schedule { get; set; } has to be define
        public int RestaurantID { get; set; }
    }
}
