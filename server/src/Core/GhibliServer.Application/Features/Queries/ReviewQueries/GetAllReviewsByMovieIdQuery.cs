using AutoMapper;
using GhibliServer.Application.Dtos.Review;
using GhibliServer.Application.Dtos.Size;
using GhibliServer.Application.Features.Queries.SizeQueries;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.ReviewQueries
{
    public class GetAllReviewsByMovieIdQuery : IRequest<ServiceResponse<List<ReviewViewDto>>>
    {
        public Guid MovieId { get; set; }
        public class GetAllReviewsByMovieIdQueryHandler : IRequestHandler<GetAllReviewsByMovieIdQuery, ServiceResponse<List<ReviewViewDto>>>
        {
            private readonly IReviewRepository _reviewRepository;
            private readonly IMapper _mapper;
            public GetAllReviewsByMovieIdQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
            {
                _reviewRepository = reviewRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<ReviewViewDto>>> Handle(GetAllReviewsByMovieIdQuery request, CancellationToken cancellationToken)
            {
                var reviews = await _reviewRepository.GetAllItemsAsync();

                var viewModel = _mapper.Map<List<ReviewViewDto>>(reviews);

                var movieReviews = viewModel.Where(x=>x.MovieId==request.MovieId).ToList();

                return new ServiceResponse<List<ReviewViewDto>>(movieReviews);
            }
        }
    }
}