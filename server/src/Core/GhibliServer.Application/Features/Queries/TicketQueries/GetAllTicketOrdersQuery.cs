using AutoMapper;
using GhibliServer.Application.Dtos.Ticket;
using GhibliServer.Application.Dtos.TicketOrder;
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
    public class GetAllTicketOrdersQuery : IRequest<ServiceResponse<List<TicketOrderViewDto>>>
    {
        public class GetAllTicketOrdersQueryHandler : IRequestHandler<GetAllTicketOrdersQuery, ServiceResponse<List<TicketOrderViewDto>>>
        {
            private readonly ITicketOrderRepository _ticketOrderRepository;
            private readonly IMapper _mapper;
            public GetAllTicketOrdersQueryHandler(ITicketOrderRepository ticketOrderRepository, IMapper mapper)
            {
                _ticketOrderRepository = ticketOrderRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<TicketOrderViewDto>>> Handle(GetAllTicketOrdersQuery request, CancellationToken cancellationToken)
            {
                var ticketOrders = await _ticketOrderRepository.GetAllItemsAsync();

                var viewModel = _mapper.Map<List<TicketOrderViewDto>>(ticketOrders);

                return new ServiceResponse<List<TicketOrderViewDto>>(viewModel);
            }
        }
    }
}