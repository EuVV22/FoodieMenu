﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Restaurants
{
    internal class RestaurantValidator : AbstractValidator<Restaurant>
    {
        public RestaurantValidator() 
        {
            RuleFor(restaurant => restaurant.RestaurantID).NotEmpty();
            RuleFor(restaurant => restaurant.Name).NotEmpty();
            RuleFor(restaurant => restaurant.Description).NotEmpty();
            RuleFor(restaurant => restaurant.email).EmailAddress();
        }
    }
}
