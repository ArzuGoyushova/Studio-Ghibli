using FluentValidation;
using GhibliServer.Application.Dtos.Color;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Movie
{
    public class MovieCreateOrUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public int RunningTime { get; set; }
        public string Genre { get; set; }
        public string TrailerVideoUrl { get; set; }
        public string MainVideoUrl { get; set; }
        public double ImdbRating { get; set; }
        public List<IFormFile>? ExistingPictures { get; set; }
        public List<IFormFile>? NewPictures { get; set; }
        public Guid CategoryId { get; set; }
    }
    public class MovieCreateOrUpdateDtoValidator : AbstractValidator<MovieCreateOrUpdateDto>
    {
        public MovieCreateOrUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(120).WithMessage("Title can't be longer than 120 characters.");
            RuleFor(x => x.Genre)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(30).WithMessage("Genre can't be longer than 30 characters.");
            RuleFor(x => x.Director)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(30).WithMessage("Director name can't be longer than 30 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Please fill in the field.");
            RuleFor(x => x.ReleaseDate)
               .NotEmpty().WithMessage("Please fill in the field.");
            RuleFor(x => x.TrailerVideoUrl)
               .NotEmpty().WithMessage("Please fill in the field.");
            RuleFor(x => x.MainVideoUrl)
               .NotEmpty().WithMessage("Please fill in the field.");
            RuleFor(x => x.ImdbRating)
               .NotEmpty().WithMessage("Please fill in the field.");
        }
    }
}
