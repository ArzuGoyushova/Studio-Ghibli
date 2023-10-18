using FluentValidation;
using GhibliServer.Application.Dtos.Account;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.About
{
    public class AboutCreateOrUpdateDto
    {
        public IFormFile? OriginImage { get; set; }
        public string OriginTitle { get; set; }
        public string OriginDesc { get; set; }
        public IFormFile? GhibliImage { get; set; }
        public string GhibliTitle { get; set; }
        public string GhibliDesc { get; set; }
        public IFormFile? GlobalImage { get; set; }
        public string GlobalTitle { get; set; }
        public string GlobalDesc { get; set; }
        public IFormFile? MessageImage { get; set; }
        public string MessageTitle { get; set; }
        public string MessageDesc { get; set; }
        public IFormFile? HeightImage { get; set; }
        public string HeightTitle { get; set; }
        public string HeightDesc { get; set; }
        public IFormFile? FutureImage { get; set; }
        public string FutureTitle { get; set; }
        public string FutureDesc { get; set; }
        
    }
    public class AboutCreateOrUpdateDtoValidator : AbstractValidator<AboutCreateOrUpdateDto>
    {
        public AboutCreateOrUpdateDtoValidator()
        {
            RuleFor(x => x.OriginTitle)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(120).WithMessage("Title can't be longer than 120 characters.");
            RuleFor(x => x.OriginDesc)
                .NotEmpty().WithMessage("Please fill in the field.");

            RuleFor(x => x.GhibliTitle)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(120).WithMessage("Title can't be longer than 120 characters.");
            RuleFor(x => x.GhibliDesc)
                .NotEmpty().WithMessage("Please fill in the field.");

            RuleFor(x => x.GlobalTitle)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(120).WithMessage("Title can't be longer than 120 characters.");
            RuleFor(x => x.GlobalDesc)
                .NotEmpty().WithMessage("Please fill in the field.");

            RuleFor(x => x.MessageTitle)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(120).WithMessage("Title can't be longer than 120 characters.");
            RuleFor(x => x.MessageDesc)
                .NotEmpty().WithMessage("Please fill in the field.");

            RuleFor(x => x.HeightTitle)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(120).WithMessage("Title can't be longer than 120 characters.");
            RuleFor(x => x.HeightDesc)
                .NotEmpty().WithMessage("Please fill in the field.");

            RuleFor(x => x.FutureTitle)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(120).WithMessage("Title can't be longer than 120 characters.");
            RuleFor(x => x.FutureDesc)
                .NotEmpty().WithMessage("Please fill in the field.");
        }
    }
}
