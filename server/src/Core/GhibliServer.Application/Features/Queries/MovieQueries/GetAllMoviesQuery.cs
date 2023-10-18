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
    public class GetAllMoviesQuery : IRequest<ServiceResponse<List<MovieViewDto>>>
    {
        public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, ServiceResponse<List<MovieViewDto>>>
        {
            private readonly IMovieRepository _movieRepository;
            private readonly IMapper _mapper;
            public GetAllMoviesQueryHandler(IMovieRepository movieRepository, IMapper mapper)
            {
                _movieRepository = movieRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<MovieViewDto>>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
            {
                var Movies = await _movieRepository.GetAllItemsWithIncludesAsync(
                    m => m.Pictures
                    );

                var viewModel = _mapper.Map<List<MovieViewDto>>(Movies);

                return new ServiceResponse<List<MovieViewDto>>(viewModel);
            }
        }
    }
}
