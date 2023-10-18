using AutoMapper;
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
    public class GetTicketOrderByIdAdminQuery : IRequest<ServiceResponse<TicketOrderViewDto>>
    {
        public Guid Id { get; set; }
        public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketOrderByIdAdminQuery, ServiceResponse<TicketOrderViewDto>>
        {
            private readonly ITicketOrderRepository _ticketOrderRepository;
            private readonly IMapper _mapper;
            public GetTicketByIdQueryHandler(ITicketOrderRepository ticketOrderRepository, IMapper mapper)
            {
                _ticketOrderRepository = ticketOrderRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<TicketOrderViewDto>> Handle(GetTicketOrderByIdAdminQuery request, CancellationToken cancellationToken)
            {
                var ticket = await _ticketOrderRepository.GetItemByIdWithIncludesAsync(
                    request.Id,
                    t => t.Tickets
                    );

                var viewModel = _mapper.Map<TicketOrderViewDto>(ticket);

                return new ServiceResponse<TicketOrderViewDto>(viewModel);
            }
        }
    }
}
