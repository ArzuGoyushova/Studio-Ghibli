using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Blog
{
    public class BlogCreateOrUpdateDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreatedTime { get; set; }
        public IFormFile? NewImage { get; set; }
        public Guid? CategoryId { get; set; }
        public string BlogContent { get; set; }
    }
    public class BlogCreateOrUpdateDtoValidator : AbstractValidator<BlogCreateOrUpdateDto>
    {
        public BlogCreateOrUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(50).WithMessage("Title can't be longer than 50 characters.");
            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(30).WithMessage("Author can't be longer than 30 characters.");
            RuleFor(x => x.BlogContent)
               .NotEmpty().WithMessage("Please fill in the field.");

        }
    }
}
