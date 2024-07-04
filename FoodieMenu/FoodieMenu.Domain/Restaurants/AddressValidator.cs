using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Restaurants
{
    public class AddressValidator : AbstractValidator<AddressRestaurant>
    {
        public AddressValidator() 
        {
            RuleFor(address => address.AddressID).NotEmpty();
            RuleFor(address =>address.AddressName).NotEmpty();
            RuleFor(address => address.Street).NotEmpty();
            RuleFor(address => address.City).NotEmpty();
            RuleFor(address => address.PostalCode).NotEmpty();
            RuleFor(address => address.RestaurantID).NotEmpty();

        }
    }
}
