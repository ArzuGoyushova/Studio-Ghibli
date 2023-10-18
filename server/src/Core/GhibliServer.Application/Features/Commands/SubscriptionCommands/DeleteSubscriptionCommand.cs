using GhibliServer.Application.Exceptions;
using GhibliServer.Application.Features.Commands.SubscriptionCommands;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.SubscriptionCommands
{
    public class DeleteSubscriptionCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid SubscriptionId { get; set; }
    }

    public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, ServiceResponse<Guid>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public DeleteSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var existingSubscription = await _subscriptionRepository.GetItemByIdAsync(request.SubscriptionId);

            if (existingSubscription == null)
            {
                throw new NotFoundException();
            }

            await _subscriptionRepository.DeleteAsync(existingSubscription.Id);

            return new ServiceResponse<Guid>(existingSubscription.Id);
        }
    }
}