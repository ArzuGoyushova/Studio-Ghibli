using AutoMapper;
using GhibliServer.Application.Dtos.Subscription;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.SubscriptionQueries
{
    public class GetAllSubscriptionsQuery : IRequest<ServiceResponse<List<SubscriptionViewDto>>>
    {
        public class GetAllSubscriptionsQueryHandler : IRequestHandler<GetAllSubscriptionsQuery, ServiceResponse<List<SubscriptionViewDto>>>
        {
            private readonly ISubscriptionRepository _subscriptionRepository;
            private readonly IMapper _mapper;
            public GetAllSubscriptionsQueryHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
            {
                _subscriptionRepository = subscriptionRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<SubscriptionViewDto>>> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
            {
                var subscriptions = await _subscriptionRepository.GetAllItemsAsync();

                var viewModel = _mapper.Map<List<SubscriptionViewDto>>(subscriptions);

                return new ServiceResponse<List<SubscriptionViewDto>>(viewModel);
            }
        }
    }
}