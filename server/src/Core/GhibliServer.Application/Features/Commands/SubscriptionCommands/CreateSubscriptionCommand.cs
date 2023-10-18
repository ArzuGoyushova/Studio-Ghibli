using AutoMapper;
using GhibliServer.Application.Dtos.Subscription;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.SubscriptionCommands
{
    public class CreateSubscriptionCommand : IRequest<ServiceResponse<Guid>>
    {
        public SubscriptionAddDto SubscriptionDTO { get; set; }
    }

    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ServiceResponse<Guid>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = _mapper.Map<Subscription>(request.SubscriptionDTO);

            await _subscriptionRepository.CreateAsync(subscription);

            return new ServiceResponse<Guid>(subscription.Id);
        }

    }
}
