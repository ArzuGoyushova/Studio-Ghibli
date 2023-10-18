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
    public class GetSubscriptionByIdQuery : IRequest<ServiceResponse<SubscriptionViewDto>>
    {
        public Guid Id { get; set; }
        public class GetSubscriptionByIdQueryHandler : IRequestHandler<GetSubscriptionByIdQuery, ServiceResponse<SubscriptionViewDto>>
        {
            private readonly ISubscriptionRepository _subscriptionRepository;
            private readonly IMapper _mapper;
            public GetSubscriptionByIdQueryHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
            {
                _subscriptionRepository = subscriptionRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<SubscriptionViewDto>> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
            {
                var subscription = await _subscriptionRepository.GetItemByIdAsync(request.Id);

                var viewModel = _mapper.Map<SubscriptionViewDto>(subscription);

                return new ServiceResponse<SubscriptionViewDto>(viewModel);
            }
        }
    }
}
