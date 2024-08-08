using FluentValidation;
using FoodieMenu.Domain.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Validators
{
    internal class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x  => x.Name).MinimumLength(1);
        }
    }
}
