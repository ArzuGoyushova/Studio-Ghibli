using FluentValidation;
using GhibliServer.Application.Dtos.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Category
{
    public class CategoryCreateOrUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public string Desc { get; set; }
    }

    public class CategoryCreateOrUpdateDtoValidator : AbstractValidator<CategoryCreateOrUpdateDto>
    {
        public CategoryCreateOrUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(50).WithMessage("Name can't be longer than 50 characters.");
            RuleFor(x => x.Desc)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(120).WithMessage("Description can't be longer than 120 characters.");

        }
    }
}
