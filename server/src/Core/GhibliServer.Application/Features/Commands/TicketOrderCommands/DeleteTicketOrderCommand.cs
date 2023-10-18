using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.TicketOrderCommands
{
    public class DeleteTicketOrderCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid TicketOrderId { get; set; }
    }

    public class DeleteTicketOrderCommandHandler : IRequestHandler<DeleteTicketOrderCommand, ServiceResponse<Guid>>
    {
        private readonly ITicketOrderRepository _ticketOrderRepository;

        public DeleteTicketOrderCommandHandler(ITicketOrderRepository ticketOrderRepository)
        {
            _ticketOrderRepository = ticketOrderRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteTicketOrderCommand request, CancellationToken cancellationToken)
        {
            var existingTicketOrder = await _ticketOrderRepository.GetItemByIdAsync(request.TicketOrderId);

            if (existingTicketOrder == null)
            {
                return null;
            }

            await _ticketOrderRepository.DeleteAsync(existingTicketOrder.Id);

            return new ServiceResponse<Guid>(existingTicketOrder.Id);
        }
    }
}

