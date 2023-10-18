using FluentValidation;
using GhibliServer.Application.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Role
{
    public class RoleCreateDto
    {
        public string Name { get; set; }
    }
    public class RoleCreateDtoValidator : AbstractValidator<RoleCreateDto>
    {
        public RoleCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(60).WithMessage("Role can't be longer than 60 characters.");
        }
    }
}
