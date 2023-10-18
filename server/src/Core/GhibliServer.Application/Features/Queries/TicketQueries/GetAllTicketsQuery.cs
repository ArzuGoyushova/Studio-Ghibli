using AutoMapper;
using GhibliServer.Application.Dtos.Ticket;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.TicketQueries
{
    public class GetAllTicketsQuery : IRequest<ServiceResponse<List<TicketViewDto>>>
    {
        public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, ServiceResponse<List<TicketViewDto>>>
        {
            private readonly ITicketRepository _ticketRepository;
            private readonly IMapper _mapper;
            public GetAllTicketsQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
            {
                _ticketRepository = ticketRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<TicketViewDto>>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
            {
                var Tickets = await _ticketRepository.GetAllItemsAsync();

                var viewModel = _mapper.Map<List<TicketViewDto>>(Tickets);

                return new ServiceResponse<List<TicketViewDto>>(viewModel);
            }
        }
    }
}
