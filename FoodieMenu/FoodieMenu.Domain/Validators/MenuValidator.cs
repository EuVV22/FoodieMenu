using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Validators
{
    internal class MenuValidator : AbstractValidator<Menu.Menu>
    {
        public MenuValidator()
        {
            RuleFor(x => x.Name).MinimumLength(1);
            RuleFor(x => x.RestaurantID).GreaterThan(0);


        }
    }
}
