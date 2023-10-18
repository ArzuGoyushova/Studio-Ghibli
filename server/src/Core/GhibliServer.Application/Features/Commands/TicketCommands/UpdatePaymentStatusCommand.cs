using AutoMapper;
using GhibliServer.Application.Exceptions;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.TicketCommands
{
    public class UpdatePaymentStatusCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid OrderId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }

    public class UpdatePaymentStatusCommandHandler : IRequestHandler<UpdatePaymentStatusCommand, ServiceResponse<Guid>>
    {
        private readonly ITicketOrderRepository _ticketOrderRepository;

        public UpdatePaymentStatusCommandHandler(ITicketOrderRepository ticketOrderRepository)
        {
            _ticketOrderRepository = ticketOrderRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdatePaymentStatusCommand request, CancellationToken cancellationToken)
        {
            var ticketOrder = await _ticketOrderRepository.GetItemByIdAsync(request.OrderId);
            if (ticketOrder == null)
            {
                throw new NotFoundException("Ticket order not found.");
            }

            ticketOrder.PaymentStatus = request.PaymentStatus;
            await _ticketOrderRepository.UpdateAsync(request.OrderId, ticketOrder);

            return new ServiceResponse<Guid>(ticketOrder.Id);
        }
    }

}
