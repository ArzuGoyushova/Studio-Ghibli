using AutoMapper;
using GhibliServer.Application.Dtos.Basket;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.TicketCommands
{
    public class CreateTicketCommand : IRequest<ServiceResponse<Guid>>
    {
        public BasketItemAddDto TicketDTO { get; set; }
    }

    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, ServiceResponse<Guid>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public CreateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = _mapper.Map<Ticket>(request.TicketDTO);

            await _ticketRepository.CreateAsync(ticket);

            return new ServiceResponse<Guid>(ticket.Id);
        }

    }
}
