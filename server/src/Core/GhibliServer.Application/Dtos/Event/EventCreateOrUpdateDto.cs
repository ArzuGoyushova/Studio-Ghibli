using FluentValidation;
using GhibliServer.Domain.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Event
{
    public class EventCreateOrUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public IFormFile? NewPicture { get; set; }
        public EventType EventType { get; set; }
        public int? MaxSeats { get; set; }
        public Guid? CategoryId { get; set; }
        public string? ReservedSeats { get; set; }
        public double Price { get; set; }
    }

    public class EventCreateOrUpdateDtoValidator : AbstractValidator<EventCreateOrUpdateDto>
    {
        public EventCreateOrUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Please fill in the field.")
                .MaximumLength(50).WithMessage("Title can't be longer than 50 characters.");
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("Please fill in the field.")
               .MaximumLength(160).WithMessage("Description can't be longer than 160 characters.");
            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Please fill in the field.");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Please fill in the field.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Please fill in the field.");
        }
    }
}
