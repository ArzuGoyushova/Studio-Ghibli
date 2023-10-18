using AutoMapper;
using GhibliServer.Application.Dtos.Movie;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.MovieQueries
{
    public class GetMovieByIdQuery : IRequest<ServiceResponse<MovieViewDto>>
    {
        public Guid Id { get; set; }
    }
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, ServiceResponse<MovieViewDto>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public GetMovieByIdQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<MovieViewDto>> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var Movie = await _movieRepository.GetItemByIdWithIncludesAsync(
                request.Id,
                p => p.Pictures,
                p => p.Category
                );

            var viewModel = _mapper.Map<MovieViewDto>(Movie);

            return new ServiceResponse<MovieViewDto>(viewModel);
        }
    }
}
