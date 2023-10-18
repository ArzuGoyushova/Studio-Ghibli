using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using global::GhibliServer.Application.Dtos.Basket;
using global::GhibliServer.Application.Interfaces.Repository;
using global::GhibliServer.Application.Wrappers;
using global::GhibliServer.Domain.Entities;
using global::GhibliServer.Domain.Helper;

namespace GhibliServer.Application.Features.Commands.TicketCommands
{
    public class CreateTicketOrderCommand : IRequest<ServiceResponse<Guid>>
    {
        public TicketOrderAddDto TicketOrderDTO { get; set; }
    }

    public class CreateTicketOrderCommandHandler : IRequestHandler<CreateTicketOrderCommand, ServiceResponse<Guid>>
    {
        private readonly ITicketOrderRepository _ticketOrderRepository;
        private readonly IMapper _mapper;

        public CreateTicketOrderCommandHandler(ITicketOrderRepository ticketOrderRepository, IMapper mapper)
        {
            _ticketOrderRepository = ticketOrderRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateTicketOrderCommand request, CancellationToken cancellationToken)
        {
            var ticketOrder = _mapper.Map<TicketOrder>(request.TicketOrderDTO);

            ticketOrder.OrderNumber = GenerateOrderNumber();
            ticketOrder.OrderDate = DateTime.Now;
            ticketOrder.PaymentStatus = PaymentStatus.Pending;

            foreach (var basketItemDto in request.TicketOrderDTO.BasketItems)
            {
                var ticket = _mapper.Map<Ticket>(basketItemDto);
                ticketOrder.Tickets.Add(ticket);
            }

            await _ticketOrderRepository.CreateAsync(ticketOrder);

            return new ServiceResponse<Guid>(ticketOrder.Id);
        }

        private string GenerateOrderNumber()
        {
            DateTime now = DateTime.UtcNow;
            string orderNumber = now.ToString("yyyyMMddHHmmss");
            return orderNumber;
        }
    }
}

