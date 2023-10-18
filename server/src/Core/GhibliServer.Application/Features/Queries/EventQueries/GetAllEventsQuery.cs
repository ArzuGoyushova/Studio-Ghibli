using AutoMapper;
using GhibliServer.Application.Dtos.Category;
using GhibliServer.Application.Dtos.Event;
using GhibliServer.Application.Features.Queries.CategoryQueries;
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
    public class GetAllEventsQuery : IRequest<ServiceResponse<List<EventViewDto>>>
    {
        public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, ServiceResponse<List<EventViewDto>>>
        {
            private readonly IEventRepository _eventRepository;
            private readonly IMapper _mapper;
            public GetAllEventsQueryHandler(IEventRepository eventRepository, IMapper mapper)
            {
                _eventRepository = eventRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<EventViewDto>>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
            {
                var events = await _eventRepository.GetAllItemsAsync();

                var viewModel = _mapper.Map<List<EventViewDto>>(events);

                return new ServiceResponse<List<EventViewDto>>(viewModel);
            }
        }
    }
}
