using AutoMapper;
using GhibliServer.Application.Dtos.Movie;
using GhibliServer.Application.Features.Commands.ProductCommands;
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
    public class UpdateMovieCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid MovieId { get; set; }
        public MovieCreateOrUpdateDto MovieDTO { get; set; }
    }

    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, ServiceResponse<Guid>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public UpdateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var existingMovie = await _movieRepository.GetItemByIdAsync(request.MovieId);

            if (existingMovie == null)
            {
                return null;
            }

            var updatedPictures = MapProfile.MapPictures(request.MovieDTO.NewPictures, "movies");
            existingMovie.Pictures.AddRange(updatedPictures);

            var hasMainPicture = existingMovie.Pictures.Any(p => p.isMain);
            if (!hasMainPicture && existingMovie.Pictures.Count > 0)
            {
                existingMovie.Pictures[0].isMain = true;
            }

            _mapper.Map(request.MovieDTO, existingMovie);

            await _movieRepository.UpdateAsync(existingMovie.Id, existingMovie);

            return new ServiceResponse<Guid>(existingMovie.Id);
        }
    }

}
