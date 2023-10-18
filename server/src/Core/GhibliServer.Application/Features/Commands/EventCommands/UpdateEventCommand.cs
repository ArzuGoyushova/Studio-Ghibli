using AutoMapper;
using GhibliServer.Application.Dtos.Event;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Profiles;
using GhibliServer.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.EventCommands
{
    public class UpdateEventCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid EventId { get; set; }
        public EventCreateOrUpdateDto EventDTO { get; set; }
    }

    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, ServiceResponse<Guid>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEvent = await _eventRepository.GetItemByIdAsync(request.EventId);

                if (existingEvent == null)
                {
                    return new ServiceResponse<Guid>(default, "Event not found.");
                }
                if (request.EventDTO.NewPicture != null)
                {
                    var uniqueFileName = MapProfile.GetUniqueFileName(request.EventDTO.NewPicture.FileName);
                    var uniqueFileNameWithExtension = uniqueFileName + Path.GetExtension(request.EventDTO.NewPicture.FileName);

                    existingEvent.ImageUrl = uniqueFileNameWithExtension;

                    string filePath = Path.Combine("https://arzugoyushova.github.io/StudioGhibli/images/event", uniqueFileNameWithExtension);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        request.EventDTO.NewPicture.CopyTo(stream);
                    }
                }
                

                _mapper.Map(request.EventDTO, existingEvent);

                await _eventRepository.UpdateAsync(existingEvent.Id, existingEvent);

                return new ServiceResponse<Guid>(existingEvent.Id);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Guid>(default, ex.Message);
            }
        }
    }

}

