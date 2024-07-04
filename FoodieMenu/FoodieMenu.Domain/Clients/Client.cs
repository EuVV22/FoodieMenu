using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Clients
{
    public class Client
    {
        [Required]
        public int ClientID { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string EmailAddress { get; set; } = string.Empty;
    }
}
