using AutoMapper;
using GhibliServer.Application.Dtos.Movie;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Profiles;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.MovieCommands
{
    public class CreateMovieCommand : IRequest<ServiceResponse<Guid>>
    {
        public MovieCreateOrUpdateDto MovieDTO { get; set; }
    }
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, ServiceResponse<Guid>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;


        public CreateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Domain.Entities.Movie>(request.MovieDTO);

            var pictures = MapProfile.MapPictures(request.MovieDTO.NewPictures, "movies");
            movie.Pictures = pictures;

            if (movie.Pictures.Count > 0)
            {
                movie.Pictures[0].isMain = true;
            }

            await _movieRepository.CreateAsync(movie);

            return new ServiceResponse<Guid>(movie.Id);
        }

    }
}
