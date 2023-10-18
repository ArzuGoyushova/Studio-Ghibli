using AutoMapper;
using GhibliServer.Application.Dtos.Event;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Profiles;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.EventCommands
{
    public class CreateEventCommand : IRequest<ServiceResponse<Guid>>
    {
        public EventCreateOrUpdateDto EventDTO { get; set; }
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, ServiceResponse<Guid>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Domain.Entities.Event>(request.EventDTO);

            if (request.EventDTO.NewPicture != null)
            {
                @event.ImageUrl = ProcessImage(request.EventDTO.NewPicture);
            }

            await _eventRepository.CreateAsync(@event);

            return new ServiceResponse<Guid>(@event.Id);
        }

        private string ProcessImage(IFormFile image)
        {
            var uniqueFileName = MapProfile.GetUniqueFileName(image.FileName);
            var uniqueFileNameWithExtension = uniqueFileName + Path.GetExtension(image.FileName);
            var imageUrl = uniqueFileNameWithExtension;

            string filePath = Path.Combine("https://arzugoyushova.github.io/StudioGhibli/images/event", uniqueFileNameWithExtension);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return imageUrl;
        }
    }

}
