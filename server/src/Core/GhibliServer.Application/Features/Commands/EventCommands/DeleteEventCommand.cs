using GhibliServer.Application.Features.Commands.EventCommands;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.EventCommands
{
    public class DeleteEventCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid EventId { get; set; }
    }
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, ServiceResponse<Guid>>
    {
        private readonly IEventRepository _eventRepository;

        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var existingEvent = await _eventRepository.GetItemByIdAsync(request.EventId);

            if (existingEvent == null)
            {
                return null;
            }

            await _eventRepository.DeleteAsync(request.EventId);

            return new ServiceResponse<Guid>(request.EventId);
        }
    }
}

