using FluentValidation;
using FoodieMenu.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Validators
{
    internal class AddressValidator : AbstractValidator<AddressRestaurant>
    {
        public AddressValidator()
        {
            RuleFor(address => address.AddressName).NotEmpty();
            RuleFor(address => address.Street).NotEmpty();
            RuleFor(address => address.City).NotEmpty();
            RuleFor(address => address.PostalCode).NotEmpty();
        }
    }
}
