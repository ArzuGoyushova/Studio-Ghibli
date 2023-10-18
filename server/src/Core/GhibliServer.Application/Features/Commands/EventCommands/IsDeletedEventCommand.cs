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
    public class IsDeletedEventCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid EventId { get; set; }
    }
    public class IsDeletedEventCommandHandler : IRequestHandler<IsDeletedEventCommand, ServiceResponse<Guid>>
    {
        private readonly IEventRepository _eventRepository;

        public IsDeletedEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(IsDeletedEventCommand request, CancellationToken cancellationToken)
        {
            await _eventRepository.IsDeletedAsync(request.EventId);

            return new ServiceResponse<Guid>(request.EventId);
        }
    }
}
