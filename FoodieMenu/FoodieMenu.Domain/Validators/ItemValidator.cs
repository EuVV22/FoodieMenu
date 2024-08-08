using FluentValidation;
using FoodieMenu.Domain.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Validators
{
    internal class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}
