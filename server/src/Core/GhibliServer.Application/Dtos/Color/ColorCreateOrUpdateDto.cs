using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Color
{
    public class ColorCreateOrUpdateDto
    {
        public string Name { get; set; }
    }
    public class ColorCreateOrUpdateDtoValidator : AbstractValidator<ColorCreateOrUpdateDto>
    {
        public ColorCreateOrUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(30).WithMessage("Name can't be longer than 30 characters.");

        }
    }
}
