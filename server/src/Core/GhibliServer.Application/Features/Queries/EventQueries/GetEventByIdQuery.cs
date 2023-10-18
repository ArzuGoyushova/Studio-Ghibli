using AutoMapper;
using GhibliServer.Application.Dtos.Event;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.EventQueries
{
    public class GetEventByIdQuery : IRequest<ServiceResponse<EventViewDto>>
    {
        public Guid Id { get; set; }
        public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, ServiceResponse<EventViewDto>>
        {
            private readonly IEventRepository _eventRepository;
            private readonly IMapper _mapper;
            public GetEventByIdQueryHandler(IEventRepository eventRepository, IMapper mapper)
            {
                _eventRepository = eventRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<EventViewDto>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
            {
                var e = await _eventRepository.GetItemByIdAsync(request.Id);

                var viewModel = _mapper.Map<EventViewDto>(e);

                return new ServiceResponse<EventViewDto>(viewModel);
            }
        }
    }
}
