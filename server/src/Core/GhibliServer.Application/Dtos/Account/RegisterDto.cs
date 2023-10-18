using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Account
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(20).WithMessage("Username can't be longer than 20 characters.");
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(20).WithMessage("Fullname can't be longer than 20 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please fill in the field.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MinimumLength(8).WithMessage("Password can't be shorter than 8 characters.")
                .MaximumLength(20).WithMessage("Password can't be longer than 20 characters.");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MinimumLength(8).WithMessage("Password can't be shorter than 8 characters.")
                .MaximumLength(20).WithMessage("Password can't be longer than 20 characters.");
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Password != x.ConfirmPassword)
                {
                    context.AddFailure("ConfirmPassword", "Confirmed Password should be the same as password.");
                }
            });
        }
    }
    }
