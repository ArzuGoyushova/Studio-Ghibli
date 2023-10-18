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

namespace GhibliServer.Application.Features.Commands.TicketOrderCommands
{
    public class UpdatePaymentStatusAdminCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid TicketOrderId { get; set; }
        public UpdatePaymentStatusDto PaymentStatusDTO { get; set; }
    }

    public class UpdatePaymentStatusAdminCommandHandler : IRequestHandler<UpdatePaymentStatusAdminCommand, ServiceResponse<Guid>>
    {
        private readonly ITicketOrderRepository _ticketOrderRepository;
        private readonly IMapper _mapper;

        public UpdatePaymentStatusAdminCommandHandler(ITicketOrderRepository ticketOrderRepository, IMapper mapper)
        {
            _ticketOrderRepository = ticketOrderRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdatePaymentStatusAdminCommand request, CancellationToken cancellationToken)
        {
            var existingTicketOrder = await _ticketOrderRepository.GetItemByIdAsync(request.TicketOrderId);

            if (existingTicketOrder == null)
            {
                return null;
            }

            _mapper.Map(request.PaymentStatusDTO, existingTicketOrder);

            await _ticketOrderRepository.UpdateAsync(existingTicketOrder.Id, existingTicketOrder);

            return new ServiceResponse<Guid>(existingTicketOrder.Id);
        }
    }
}
