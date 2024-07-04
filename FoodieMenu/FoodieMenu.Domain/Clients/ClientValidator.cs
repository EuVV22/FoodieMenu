using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieMenu.Domain.Clients
{
    internal class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator() 
        {
            RuleFor(client => client.ClientID).NotNull();
            RuleFor(client => client.LastName).MinimumLength(1);
            RuleFor(client => client.EmailAddress).EmailAddress();
        }
    }
}
