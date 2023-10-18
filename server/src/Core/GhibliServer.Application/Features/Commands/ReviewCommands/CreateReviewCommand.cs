using AutoMapper;
using GhibliServer.Application.Dtos.Review;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.ReviewCommands
{
    public class CreateReviewCommand : IRequest<ServiceResponse<Guid>>
    {
        public ReviewAddDto ReviewDTO { get; set; }
    }

    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ServiceResponse<Guid>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = _mapper.Map<Review>(request.ReviewDTO);

            await _reviewRepository.CreateAsync(review);

            return new ServiceResponse<Guid>(review.Id);
        }

    }
}
