using FluentValidation;
using GhibliServer.Application.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Subscription
{
    public class SubscriptionAddDto
    {
        public string Email { get; set; }
    }

    public class SubscriptionAddDtoValidator : AbstractValidator<SubscriptionAddDto>
    {
        public SubscriptionAddDtoValidator()
        {
            RuleFor(x => x.Email)
              .NotEmpty().WithMessage("Please fill in the field.")
              .EmailAddress().WithMessage("Invalid email format.");
        }
    }
      
}
