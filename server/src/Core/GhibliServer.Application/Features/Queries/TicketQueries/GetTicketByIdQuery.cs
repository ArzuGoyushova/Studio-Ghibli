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
    public class GetTicketByIdQuery : IRequest<ServiceResponse<TicketViewDto>>
    {
        public Guid Id { get; set; }
        public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, ServiceResponse<TicketViewDto>>
        {
            private readonly ITicketRepository _ticketRepository;
            private readonly IMapper _mapper;
            public GetTicketByIdQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
            {
                _ticketRepository = ticketRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<TicketViewDto>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
            {
                var Ticket = await _ticketRepository.GetItemByIdAsync(request.Id);

                var viewModel = _mapper.Map<TicketViewDto>(Ticket);

                return new ServiceResponse<TicketViewDto>(viewModel);
            }
        }
    }
}
