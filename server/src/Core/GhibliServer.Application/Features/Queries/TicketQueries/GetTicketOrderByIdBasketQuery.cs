using AutoMapper;
using GhibliServer.Application.Dtos.Basket;
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
    public class GetTicketOrderByIdBasketQuery : IRequest<ServiceResponse<TicketOrderViewDto>>
    {
        public Guid Id { get; set; }
        public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketOrderByIdBasketQuery, ServiceResponse<TicketOrderViewDto>>
        {
            private readonly ITicketOrderRepository _ticketRepository;
            private readonly IMapper _mapper;
            public GetTicketByIdQueryHandler(ITicketOrderRepository ticketRepository, IMapper mapper)
            {
                _ticketRepository = ticketRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<TicketOrderViewDto>> Handle(GetTicketOrderByIdBasketQuery request, CancellationToken cancellationToken)
            {
                var ticket = await _ticketRepository.GetItemByIdAsync(request.Id);

                var viewModel = _mapper.Map<TicketOrderViewDto>(ticket);

                return new ServiceResponse<TicketOrderViewDto>(viewModel);
            }
        }
    }
}
